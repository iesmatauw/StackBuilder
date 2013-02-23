#define Net20 //remove or comment this line to remove any functionality only available in .net 2.0 (and higher)

namespace TreeDim.UserControls
{
    /*
    * For complete functionality, you need these 2 components (if not added allready)
    * the OutlookDropCatcher: http://blogs.vbcity.com/hotdog/archive/2006/03/16/5896.aspx 
    * the fileextension class: http://blogs.vbcity.com/hotdog/archive/2006/03/07/5873.aspx
    * 
    */
    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.IO;
    using TreeDim.IO;
    using System.Drawing;
    /// 
    /// Control to quickly select files
    /// 
    [DefaultProperty("FileName")]
    [DefaultEvent("FileNameChanged")]
    public class FileSelect : UserControl, INotifyPropertyChanged
    {
        #region Constructor
        /// Source : http://blogs.vbcity.com/hotdog/archive/2006/03/03/5861.aspx
        /// 
        private FileBox txtFile;
        private BrowseButton btn = new BrowseButton();
        public FileSelect()
        {
            CreateTextBox();
            btn.Bounds = new Rectangle(Width - btn.Width - pad, pad, btn.Width, Height - 2 * pad - 1);
            btn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            Controls.Add(btn);
            btn.Click += new EventHandler(btn_Click);
            base.AllowDrop = true;
            file.FileChanged += new EventHandler(file_FileChanged);
            this.EnabledChanged += new EventHandler(FileSelect_EnabledChanged);
        }
        void FileSelect_EnabledChanged(object sender, EventArgs e)
        {
            Invalidate(true);
        }
        #endregion
        #region textbox
        const int pad = 2;
        void CreateTextBox()
        {
            txtFile = new FileBox(this);
            SetControl(txtFile);
        }
        class FileBox : TextBox
        {
            readonly FileSelect owner;
            public FileBox(FileSelect Owner)
            {
                this.owner = Owner;
                AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteSource = AutoCompleteSource.FileSystem;
                AutoSize = false;
            }
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                UserPaint = true;
            }
            protected override void OnValidated(EventArgs e)
            {
                owner.EndEditCurrentFile();
                base.OnValidated(e);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                Enabled = owner.Enabled;
                e.Graphics.Clear(Enabled ? Color.White : System.Drawing.SystemColors.ButtonFace);
                if (Enabled)
                    owner.file.DrawFile(e.Graphics, DisplayRectangle, Font, true);
                base.OnPaint(e);
            }

            protected override void OnDoubleClick(EventArgs e)
            {
                SelectAll();
                base.OnDoubleClick(e);
            }
            bool UserPaint
            {
                set
                {
                    SetStyle(ControlStyles.UserPaint, value);
                }
            }
            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);
                SelectAll();
                UserPaint = false;
            }
            protected override void OnLeave(EventArgs e)
            {
                UserPaint = true;
                base.OnLeave(e);
            }
        }
        #endregion
        #region ListView (used for detailed and MultiSelect view)
        FileList list;
        class FileList : ListBox
        {
            public FileList(FileSelect owner)
            {
                this.DrawMode = DrawMode.OwnerDrawFixed;
            }
            protected override void OnDrawItem(DrawItemEventArgs e)
            {
                FileData data = Items[e.Index] as FileData;
                if (data == null)
                {
                    Font f = new Font(Font, FontStyle.Italic | FontStyle.Underline);
                    e.Graphics.DrawString("New", f, Brushes.Blue, 0, 0);
                }
                else
                    data.DrawFile(e.Graphics, e.Bounds, e.Font, true);
                base.OnDrawItem(e);
            }
            protected override void OnSelectedIndexChanged(EventArgs e)
            {
                base.OnSelectedIndexChanged(e);
            }
        }
        #endregion
        #region Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                Browse();
                return true;
            }
            if (keyData == Keys.Enter)
            {
                EndEditCurrentFile();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        #region properties
        private FileData file = new FileData();
        [Description("The current file name")]
        [SettingsBindable(true)]
        [DefaultValue(null)]
        public string FileName
        {
            get { return file.FileName; }
            set
            {
                file.FileName = value;
            }
        }
        void file_FileChanged(object sender, EventArgs e)
        {
            txtFile.Text = file.FileName;
            OnPropertyChanged("FileName", FileNameChanged);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FileData Info
        {
            get { return file; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Folder
        {
            get { return file.Folder; }
            set
            {
                file.Folder = value;
            }
        }
        public event EventHandler FileNameChanged;

        void EndEditCurrentFile()
        {
            FileName = txtFile.Text;
        }

        /// 
        /// Returns if the selected file exists
        /// 
        public bool IsValid
        {
            get
            {
                return file.IsValid;
            }
        }
        [DefaultValue(true)]
        [Description("If true (Default) the user can type in files manually. If false, only the dialog (browse button) can be used")]
        public bool AllowTextEdit
        {
            get { return !txtFile.ReadOnly; }
            set
            {
                if (value == AllowTextEdit) return;
                txtFile.ReadOnly = !value;
                txtFile.BackColor = value ? Color.Empty : Color.White;
                OnPropertyChanged("AllowTextEdit", null);
            }
        }
        private bool savemode;
        [DefaultValue(false)]
        [Description("The mode the file dialog is used. If this value is true, a savedialog is used, if false (default) an open dialog is used")]
        public bool SaveMode
        {
            get { return savemode; }
            set
            {
                if (savemode == value) return;
                savemode = value;
                fd = null;
                OnPropertyChanged("SaveMode", null);
            }
        }
        string filter;
        [DefaultValue(null)]
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                if (value != null && value.Trim().Length == 0)
                    value = null;
                filter = value;
            }
        }
        #endregion
        #region Dialog
        FileDialog fd;
        /// 
        /// Gets the underlying .
        /// The type of dialog depends on the setting
        /// 
        public FileDialog FileDialog
        {
            get
            {
                if (fd == null)
                    fd = savemode ? (FileDialog)new SaveFileDialog() : new OpenFileDialog();
                return fd;
            }
        }
        /// 
        /// Opens the browse dialog
        /// 
        public void Browse()
        {
            if (file != null)
            {
                FileDialog.InitialDirectory = Folder;
                if (file.IsValid)
                    FileDialog.FileName = file.Info.Name;
            }
            fd.Filter = filter;
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                FileName = fd.FileName;
            }
        }
        #endregion
        #region Drag/drop
        [DefaultValue(true)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }
        protected override void OnDragEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            base.OnDragEnter(e);
        }
        protected override void OnDragDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                AddFiles(
                (string[])e.Data.GetData(DataFormats.FileDrop));
            base.OnDragDrop(e);
        }
        #endregion
        #region Selected files
        public const int
        DefaultHeightSingle = 20,
        DefaultHeightMulti = 60;
        /// 
        /// more than 1?....
        /// Not supported yet...
        /// 
        [DefaultValue(false)]
        bool MultiSelect
        {
            get
            {
                return list != null;
            }
            set
            {
                if (value == MultiSelect) return;
                txtFile.Visible = !value;
                if (value)
                {
                    list = new FileList(this);
                    SetControl(list);
                    if (FileName != null)
                        list.Items.Add(file);
                    list.Items.Add("New");
                }
                else
                {
                    list.Dispose();
                    list = null;
                }
                if (DesignMode)
                    Height = value ? DefaultHeightMulti : DefaultHeightSingle;
            }
        }
        void AddFiles(params string[] files)
        {
            if (files == null || files.Length == 0)
                return;//FileName = null;
            else if (MultiSelect)
            {
                list.Items.RemoveAt(list.Items.Count - 1);
                foreach (string s in files)
                {
                    list.Items.Add(new FileData(s));
                }
                list.Items.Add("New");
            }
            else
                FileName = files[0];
        }
        #endregion
        #region Browse button
        void btn_Click(object sender, EventArgs e)
        {
            Browse();
            txtFile.SelectAll();
            txtFile.Focus();
        }
        class BrowseButton : Button
        {
            public BrowseButton()
            {
                FlatStyle = FlatStyle.Flat;
                TabStop = false;
                BackColor = Color.LightGray;
            }
            protected override Size DefaultSize
            {
                get
                {
                    return new Size(18, 18);
                }
            }
            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);
                pevent.Graphics.DrawString("...", Font, Brushes.Black, 2, 0);
            }
        }
        #endregion
        #region Appearance
        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, DefaultHeightSingle);
            }
        }
        void SetControl(Control c)
        {
            if (c is TextBox)
                (c as TextBox).BorderStyle = System.Windows.Forms.BorderStyle.None;
            else
                (c as ListBox).BorderStyle = System.Windows.Forms.BorderStyle.None;
            //no docking used because the displayrectangle property uses the Padding property as well
            c.Bounds = new Rectangle(pad, pad, Width - btn.Width - pad * 2 - 1, Height - pad * 2);
            c.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            Controls.Add(c);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle r = DisplayRectangle;
            ControlPaint.DrawBorder3D(e.Graphics, r, bstyle);
        }
        static Border3DStyle defaultBorderStyle = Border3DStyle.Etched;
        Border3DStyle bstyle = defaultBorderStyle;
        public new Border3DStyle BorderStyle
        {
            get { return bstyle; }
            set
            {
                bstyle = value;
                Invalidate();
            }
        }
        bool ShouldSerializeBorderStyle()
        {
            return BorderStyle != defaultBorderStyle;
        }
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return Color.White;
            }
            set { }
        }
        bool ShouldSerializeBackColor()
        {
            return false;
        }
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string Name, EventHandler ChangedHandler)
        {
            if (ChangedHandler != null)
                ChangedHandler(this, EventArgs.Empty);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
        #endregion
    }

}
namespace TreeDim.IO
{

    using System;
#if Net20
    using System.Collections.Generic;
#else
    using System.Collections;
#endif
    using System.Text;
    using Microsoft.Win32;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;





    /// <summary>
    /// Information around a registered file extension.
    /// Use the static functions to get lists
    /// </summary>
    public partial class FileExtension : FileRegKey
    {
        public FileExtension(string Extension)
            : base(Extension)
        {
        }
        /// <summary>
        /// The extension this <see cref=&quotFileExtension"/> class holds information for
        /// </summary>
        public string Extension
        {
            get { return Name; }
            set
            {
                Name = value;
            }
        }
        protected override bool CheckValue(ref string value)
        {
            if (!CheckExtension(value))
                throw new Exception("Extension format: " + value
                + ".\nFormat should be a dot followed by one or more allowed characters (Vague isn't it? See the AllowedCharacters constant for a list. Of course letters and digits are also allowed).");
            return base.CheckValue(ref value);
        }
        #region Registry

        protected override void onKeyChanged()
        {
            setStarter();
            base.onKeyChanged();
        }
        public override void Refresh()
        {
            starter = null;
            base.Refresh();
        }
        /// <summary>
        /// The value defined in the main registry entry that points
        /// to the key that contains the start information. This value can be the
        /// same as that of other extensions to use the same data (eg, .zip,.pkzip,.tar can point to the same location)
        /// NB, changing this property means creating a new <see cref=&quotStarter"/>
        /// 
        /// In general it's more user friendly to assign this through the <see cref=&quotStarter"/> property unless
        /// assigning to an existing info entry
        /// </summary>
        public string AssociatedName
        {
            get
            {
                return DefaultValue as string;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (DefaultValue != null && AssociatedName.ToLower() == value.ToLower())
                    return;
                DefaultValue = value;
                setStarter();
            }
        }
        #endregion
        private FileStarter starter;
        /// <summary>
        /// The <see cref=&quotFileStarter"/> information associated with this file
        /// </summary>
        public FileStarter Starter
        {
            get
            {
                GetKey();
                if (starter == null) //create a default starter
                    AssociatedName = Extension.Substring(1) + " Files";
                return starter;
            }
            set
            {
                starter = value;
                AssociatedName = value == null ? null : value.Name;
            }
        }


        private void setStarter()
        {
            if (Exists())
            {
                string subname = AssociatedName;
                if (subname != null)
                {
                    if (starter == null || starter.Name.ToLower() != subname.ToLower())
                        starter = new FileStarter(subname);
                    return;
                }
            }
            starter = null;
        }
        /// <summary>
        /// Gets the description of the associated file
        /// You can set this property through the <see cref=&quotStarter"/> property.
        /// If no <see cref=&quotStarter"/> is assigned, the contenttype is returned
        /// </summary>
        public string Description
        {
            get
            {
                GetKey();
                if (starter == null) return ContentType;
                return starter.Description;
            }
        }
        /// <summary>
        /// Gets the icon-name of the associated <see cref=&quotStarter"/>
        /// </summary>
        /// <returns></returns>
        public string GetIconName()
        {
            GetKey();
            if (starter == null) return null;
            return starter.IconFileName;
        }
        /// <summary>
        /// Gets the icon of the associated <see cref=&quotStarter"/>
        /// </summary>
        /// <returns></returns>
        public Icon GetIcon()
        {
            GetKey();
            if (starter == null) return GetDefaultIcon();
            return starter.GetIcon();
        }
        static Icon defaultIcon;
        /// <summary>
        /// Gets the icon used for unknown file types
        /// </summary>
        /// <returns></returns>
        public static Icon GetDefaultIcon()
        {
            if (defaultIcon == null)
            {
                defaultIcon = ExtractIcon("shell32.dll");
            }
            return defaultIcon;
        }
        public static Icon ExtractIcon(string File)
        {
            return ExtractIcon(File, 0);
        }
        public static Icon ExtractIcon(string File, int Index)
        {
            //In .net 2.0 there's a static method Icon.ExtractAssociatedIcon, but this does not support
            //indexes (only the first icon is extracted)
            //that's why for version 2.0 as well as the prior ones, the dllimport below is used
            IntPtr h = ExtractIcon(0, File, Index);
            return Icon.FromHandle(h);
        }
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        extern static IntPtr ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);

        const string ContentTypeValue = "Content Type";
        /// <summary>
        /// The content type description for the current entry.
        /// </summary>
        public string ContentType
        {
            get
            {
                return GetValue(ContentTypeValue) as string;
            }
            set
            {
                SetValue(ContentTypeValue, value);
            }
        }

        /// <summary>
        /// Returns the extension and the descriptive text
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Extension + ": " + Description;
        }
    }
    /// <summary>
    /// Base class for <see cref=&quotFileExtension"/> and <see cref=&quotFileStarter"/>
    /// </summary>
    public class FileRegKey : RegKey
    {
        public FileRegKey(string Name)
            : base(Registry.ClassesRoot, Name)
        {
        }
    }
    /// <summary>
    /// Wrapper around a <see cref=&quotMicrosoft.Win32.RegistryKey"/>
    /// </summary>
    public class RegKey
    {
        public readonly RegKey Root;
        private RegistryKey rootkey;
        public RegistryKey RootKey
        {
            get
            {
                if (Root == null)
                    return rootkey;
                return Root.RegistryKey;
            }
        }
        public string FullName
        {
            get
            {
                return (Root == null
                ? rootkey.Name
                : Root.FullName)
                + @"\" + name;
            }
        }
        public RegKey(RegKey BaseDir, string Name)
        {
            if (BaseDir == null) throw new ArgumentNullException();
            Root = BaseDir;
            this.Name = Name;
        }
        public RegKey(RegistryKey BaseDir, string Name)
        {
            if (BaseDir == null) throw new ArgumentNullException();
            this.rootkey = BaseDir;
            this.Name = Name;
        }
        private string name;
        /// <summary>
        /// The name of the key.
        /// NB, changing the name looks up or creates a new key, it will not
        /// rename the existing one
        /// </summary>
        internal string Name
        {
            get { return name; }
            set
            {
                if (name != null && !AllowNameChange()) return; //throw instead?
                if (value == null)
                    throw new ArgumentNullException();
                if (CheckValue(ref value))
                {
                    name = value;
                    Refresh();
                }
            }
        }
        protected virtual bool AllowNameChange()
        {
            return true;
        }
        /// <summary>
        /// Normally the registry key is looked up once and the values buffered, but if an external program has altered
        /// the registry, you can force a refresh with this method
        /// </summary>
        public virtual void Refresh()
        {
            regkey = null;
            regkeysSearched = false;
        }
        protected virtual bool CheckValue(ref string value)
        {
            return true;
        }
        /// <summary>
        /// Indicates if this key already exists
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            GetKey();
            return regkey != null;
        }
        bool regkeysSearched;
        RegistryKey regkey;
        /// <summary>
        /// Gets the corresponding registry key (if any)
        /// </summary>
        public RegistryKey RegistryKey
        {
            get
            {
                GetKey();
                return regkey;
            }
        }
        /// <summary>
        /// The default value for the current entry
        /// </summary>
        public object DefaultValue
        {
            get
            {
                return GetValue(null);
            }
            set
            {
                SetValue(null, value);
            }
        }
        public object GetValue(string Name)
        {
            GetKey();
            if (regkey == null) return null;
            return regkey.GetValue(Name);
        }
        public void SetValue(string Name, object value)
        {
            Writable = true;
            RegistryKey.SetValue(Name, value);
        }
        /// <summary>
        /// Forcibly creates this subkey
        /// </summary>
        public void Create()
        {
            if (!Exists())
            {
                if (Root != null) Root.Writable = true;
                RootKey.CreateSubKey(name);
                Refresh();
            }
        }
        /// <summary>
        /// Forces a flush of the changes if values have been changed
        /// </summary>
        public void Flush()
        {
            if (regkey != null) regkey.Flush();
        }
        /// <summary>
        /// Writes any changes to disk
        /// </summary>
        public void Close()
        {
            if (regkey != null) regkey.Close();
        }
        /// <summary>
        /// Gets a <see cref=&quotRegKey"/> indicating a subkey for this item.
        /// If it doesn't exist, it will be created if a value is set.
        /// You can also use <see cref=&quotCreateSubKey"/> to ensure it is created.
        /// </summary>
        /// <param name=&quotName"></param>
        /// <returns></returns>
        public RegKey GetSubKey(string Name)
        {
            return new RegKey(this, Name);
        }
        /// <summary>
        /// Same as <see cref=&quotGetSubKey"/>, but this method forces the creation 
        /// where <see cref=&quotGetSubKey"/> just returns the object which will create
        /// itself when needed (a value is set)
        /// </summary>
        /// <param name=&quotName"></param>
        /// <returns></returns>
        public RegKey CreateSubKey(string Name)
        {
            RegKey key = GetSubKey(Name);
            if (!key.Exists())
                key.Create();
            return key;
        }
        /// <summary>
        /// Get the registry information if not done so already after the last Refresh
        /// </summary>
        protected void GetKey()
        {
            if (!regkeysSearched)
            {
                regkeysSearched = true;
                if (Root == null)
                {
                    if (rootkey == null)
                        throw new Exception("No root was specified!");
                }
                else if (Root.Exists())
                {
                    //RegistryKey classes = ;
                    rootkey = Root.RegistryKey;
                }
                if (rootkey != null)
                    regkey = rootkey.OpenSubKey(name, writable);
                onKeyChanged();
            }
        }
        private bool writable;
        /// <summary>
        /// The current state of the registry key. This property can be set manually, but
        /// this isn't really necessary. Normally a key is opened as readonly and switched
        /// to writable only when required.
        /// NB: when set to writable, this key will be created when it doesn't exist yet (see <see cref=&quotCreate"/>)
        /// </summary>
        public bool Writable
        {
            get { return writable; }
            set
            {
                if (writable == value) return;
                writable = value;
                if (value)
                {
                    Create();
                }
                Refresh();
            }
        }

        protected virtual void onKeyChanged()
        {
        }
    }
    /// <summary>
    /// The extra info for a <see cref=&quotFileExtension"/>. This is a reusable entry that
    /// can be used for multiple extensions.
    /// eg, one starter can be used for ".zip",".tar",".gz", etc.
    /// </summary>
    public class FileStarter : FileRegKey
    {
        public FileStarter(string Name)
            : base(Name)
        {
        }
        /// <summary>
        /// The description of the files that are started by this entry
        /// </summary>
        public string Description
        {
            get { return DefaultValue as string; }
            set
            {
                DefaultValue = value;
            }
        }
        const string showextValueName = "AlwaysShowExt";
        /// <summary>
        /// Self descriptive really eh :p
        /// </summary>
        public bool AlwaysShowExtension
        {
            get
            {
                object o = GetValue(showextValueName);
                if (o == null) return false;
                return (int)o == 1;
            }
            set
            {
                if (AlwaysShowExtension == value) return;
                if (value)
                    SetValue(showextValueName, 1);
                else if (Exists())
                    this.RegistryKey.DeleteValue(showextValueName);
            }
        }
        const string defaultIconEntry = "DefaultIcon";
        /// <summary>
        /// The name of the icon associated with this type
        /// </summary>
        public string IconFileName
        {
            get
            {
                RegKey key = GetIconEntry();
                if (key == null) return null;
                return key.DefaultValue as string;
            }
            set
            {
                RegKey key = GetIconEntry();
                if (key != null)
                    key.DefaultValue = value;
            }
        }
        /// <summary>
        /// Loads the icon specified in <see cref=&quotIconFileName"/>
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Icon GetIcon()
        {
            string file = IconFileName;
            if (file != null)
            {
                if (File.Exists(file))
                    return new System.Drawing.Icon(file);
                else
                {
                    int p = file.LastIndexOf(',');
                    int i;
                    if (p != -1 && int.TryParse(file.Substring(p + 1), out i))
                    {
                        return FileExtension.ExtractIcon(file.Substring(0, p), i);
                    }
                }
            }
            return FileExtension.GetDefaultIcon();
        }
        public RegKey GetIconEntry()
        {
            return GetSubKey(defaultIconEntry);
        }
        protected override void onKeyChanged()
        {
            shell = shellex = null;
            base.onKeyChanged();
        }
        FileStarterShell shell, shellex;
        /// <summary>
        /// Contains the actual start information
        /// </summary>
        public FileStarterShell Shell
        {
            get
            {
                if (shell == null)
                    shell = new FileStarterShell(this, false);
                return shell;
            }
        }
        /// <summary>
        /// The application or command used to open the file.
        /// If you assign this value manually, don't forget to add a "%1" if you want
        /// to include the file to open
        /// </summary>
        public string OpenCommand
        {
            get { return Shell.OpenCommand; }
            set { Shell.OpenCommand = value; }
        }
        /// <summary>
        /// Contains the start information if it has to use ShellEx.
        /// Normally you don't have to use this and can use <see cref=&quotShell"/> instead
        /// </summary>
        public FileStarterShell ShellEx
        {
            get
            {
                if (shellex == null)
                    shellex = new FileStarterShell(this, true);
                return shellex;
            }
        }
    }
    /// <summary>
    /// The actual shell info to start a <see cref=&quotFileStarter"/> application
    /// </summary>
    public class FileStarterShell : RegKey
    {
        public FileStarterShell(FileStarter owner, bool Ex)
            : base(owner, Ex ? "shellEx" : "shell")
        {
            Open = AddMenu("open");
            Edit = AddMenu("edit");
            PrintTo = AddMenu("printto");
            Play = AddMenu("play");
        }
        /// <summary>
        /// Commands to normally open a file (doubleclick in explorer)
        /// </summary>
        public readonly FileStarterShellMenu Open;
        /// <summary>
        /// Commands to edit a file (edit in the right click explorer menu)
        /// </summary>
        public readonly FileStarterShellMenu Edit;
        /// <summary>
        /// Commands when to print (print in right click explorer menu)
        /// </summary>
        public readonly FileStarterShellMenu PrintTo;
        /// <summary>
        /// Commands with which to play (play in right click explorer menu, used for media files)
        /// </summary>
        public readonly FileStarterShellMenu Play;
        /// <summary>
        /// Returns the menu with the specified name.
        /// The default menus such as Open and PrintTo can also be obtained directly
        /// </summary>
        /// <param name=&quotMenuName"></param>
        /// <returns></returns>
        public FileStarterShellMenu this[string MenuName]
        {
            get
            {
                string search = MenuName.ToLower();
                foreach (FileStarterShellMenu f in menus)
                {
                    if (f.Name == search) return f;
                }
                return AddMenu(MenuName);
            }
        }
        /// <summary>
        /// An extra function around the indexed property to make it easier to find ;-)
        /// </summary>
        /// <param name=&quotMenuName"></param>
        /// <returns></returns>
        public FileStarterShellMenu GetMenu(string MenuName)
        {
            return this[MenuName];
        }
        private FileStarterShellMenu AddMenu(string name)
        {
            FileStarterShellMenu m = new FileStarterShellMenu(this, name);
            menus.Add(m);
            return m;
        }
#if Net20
        List<FileStarterShellMenu> menus = new List<FileStarterShellMenu>();
#else
ArrayList menus = new ArrayList();
#endif
        /// <summary>
        /// sets the commandline (application) to open the file
        /// </summary>
        public string OpenCommand
        {
            get { return Open.Command; }
            set { Open.Command = value; }
        }
        protected override bool AllowNameChange()
        {
            return false;
        }
    }
    public class FileStarterShellMenu : RegKey
    {
        public readonly FileStarterShell Owner;
        internal FileStarterShellMenu(FileStarterShell owner, string Name)
            : base(owner, Name)
        {
            this.Owner = owner;
            commandKey = new RegKey(this, "command");
        }
        protected override bool AllowNameChange()
        {
            return false;
        }
        readonly RegKey commandKey;
        /// <summary>
        /// Assign the command to start up with the specified application
        /// </summary>
        /// <param name=&quotpath"></param>
        public void SetApplication(string path)
        {
            Command = path + @" %1";
        }
        public string Command
        {
            get { return commandKey.DefaultValue as string; }
            set { commandKey.DefaultValue = value; }
        }
    }
    /// <summary>
    /// This part of the class contains the static functions
    /// </summary>
    public partial class FileExtension
    {
#if Net20
        public static IEnumerable<FileExtension> EnumerateExtensionInfo()
        {
            foreach (string subkeyname in GetRegisteredExtensions())
            {
                yield return new FileExtension(subkeyname);
            }
        }
        /// <summary>
        /// Returns the names of all the registered extensions (including the general '*').
        /// The StartsWith value indicates what to search for (null or "." returns all, &quotex" returns ".exe",".ex_" etc)
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetRegisteredExtensions(string StartsWith)
        {
            return GetRegisteredExtensions(StartsWith, false);
        }
        public static IEnumerable<string> GetRegisteredExtensions()
        {
            return GetRegisteredExtensions(".", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name=&quotStartsWith"></param>
        /// <param name=&quotIncludeDefault"><c>true</c> if the general '*' entry should be included, otherwise <c>false</c></param>
        /// <returns></returns>
        public static IEnumerable<string> GetRegisteredExtensions(string StartsWith, bool IncludeDefault)
        {
            if (IncludeDefault)
                yield return "*";
            RegistryKey classes = Registry.ClassesRoot;
            foreach (string subkeyname in classes.GetSubKeyNames())
            {
                if (subkeyname.StartsWith(StartsWith))
                    yield return subkeyname;
            }
        }
#endif
        /// <summary>
        /// Characters that are allowed besides characters or digits.
        /// </summary>
        public const string AllowedCharacters = "-_";
        /// <summary>
        /// Checks if the specified Extension has a valid setup
        /// </summary>
        /// <param name=&quotExtension"></param>
        /// <returns></returns>
        public static bool CheckExtension(string Extension)
        {
            if (Extension == "*") return true;
            //check extension type (could have used regex, but went for the speed)
            if (Extension.Length < 2) return false;
            if (Extension[0] != '.') return false;
            for (int i = 1; i < Extension.Length; i++)
            {
                if (!char.IsLetterOrDigit(Extension[i]))
                {
                    if (AllowedCharacters.IndexOf(Extension[i]) == -1)
                        return false;
                }
            }
            return true;
        }
        static RegistryKey RenameKey(RegistryKey key, string NewName)
        {
            //must be a better way than this to simply rename...
            string name = key.Name;
            return key;
        }

        /// <summary>
        /// Sets the application as the name for the startup group
        /// </summary>
        /// <param name=&quotApplication"></param>
        /// <param name=&quotExtension"></param>
        public static FileExtension RegisterApplication(string Application, string Extension)
        {
            FileExtension ext = new FileExtension(Extension);
            ext.Starter.Shell.Open.SetApplication(Application);
            return ext;
        }
        /// <summary>
        /// assigns the specified extension to an existing application group
        /// </summary>
        /// <param name=&quotStarterGroup"></param>
        /// <param name=&quotExtension"></param>
        public static FileExtension AssignExtension(string StarterGroup, string Extension)
        {
            FileExtension ext = new FileExtension(Extension);
            ext.AssociatedName = StarterGroup;
            return ext;
        }
    }

    /// <summary>
    /// Wrapper around the <see cref=&quotSystem.IO.FileInfo"/>, with some extra functionality such as the extension
    /// </summary>
    public class FileData
    {
        private FileInfo file;
        public FileData() { }
        public FileData(string File)
        {
            FileName = File;
        }
        /// <summary>
        /// The filename for which this info is set
        /// </summary>
        public string FileName
        {
            get { return file == null ? null : file.FullName; }
            set
            {
                if (FileName == value) return;
                if (value == null || value.Trim().Length == 0)
                {
                    file = null;
                }
                else
                {
                    file = new FileInfo(value);
                }
                valid = file != null && file.Exists;
                icon = null;
                ext = null;
                if (FileChanged != null)
                    FileChanged(this, EventArgs.Empty);
            }
        }
        public event EventHandler FileChanged;
        bool valid;
        /// <summary>
        /// Indicates whether a file is set and exists
        /// </summary>
        public bool IsValid
        {
            get { return valid; }
        }
        /// <summary>
        /// Returns the underlying <see cref=&quotFileInfo"/> object
        /// </summary>
        public FileInfo Info
        {
            get { return file; }
        }
        /// <summary>
        /// The folder in which the file is held
        /// </summary>
        public string Folder
        {
            get { return file != null ? file.DirectoryName : null; }
            set
            {
                if (file == null || Folder == value) return;
                FileName = value + @"\" + (valid ? file.Name : null);
            }
        }
        FileExtension ext;
        /// <summary>
        /// returns the extension information. NB: getting some properies of the Extension
        /// causes registry entries to be created (by design).
        /// If that is not the intention, check Extension.Exists() first.
        /// </summary>
        public FileExtension ExtensionInfo
        {
            get
            {
                if (ext == null && valid && FileExtension.CheckExtension(Extension))
                    ext = new FileExtension(Extension);
                return ext;
            }
        }
        public string Extension
        {
            get
            {
                if (file == null) return null;
                return file.Extension;
            }
        }


        Icon icon;
        public Icon AssociatedIcon
        {
            get
            {
                if (icon == null)
                {
#if Net20
                    if (valid)
                        try
                        {
                            icon = Icon.ExtractAssociatedIcon(FileName); //long live this new functionality!
                        }
                        catch { }
                    if (icon == null)
#endif
                        if (ExtensionInfo != null)
                            icon = ext.GetIcon();
                }
                return icon;
            }
        }

#if Net20
        public void DrawFile(Graphics g, Rectangle bounds, Font Font, bool IncludeIcon)
        {
            if (IncludeIcon)
            {
                int hw = Math.Min(32, bounds.Height - 2);
                int y = (bounds.Height - hw) / 2;
                Rectangle rIcon = new Rectangle(1, y, hw, hw);
                if (AssociatedIcon != null)
                    g.DrawIcon(AssociatedIcon, rIcon);
                else
                {
                    rIcon.Inflate(-2, -2);
                    Pen pen = Pens.Red;
                    g.DrawRectangle(pen, rIcon);
                    g.DrawLine(pen, rIcon.X, rIcon.Y, rIcon.Right, rIcon.Bottom);
                    g.DrawLine(pen, rIcon.X, rIcon.Bottom, rIcon.Right, rIcon.Y);
                }

                hw = rIcon.Right + 4;
                bounds.Offset(hw, 0);
                bounds.Width -= hw;
            }
            string text = FileName;
            SizeF s = g.MeasureString(text, Font);
            if (s.Width < bounds.Width)
            {
                g.DrawString(text, Font, Brushes.Black, bounds);
            }
            else
            {
                TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.Right | TextFormatFlags.EndEllipsis;
                TextRenderer.DrawText(g, file.Name, Font, bounds, Color.Black, flags);
                s = TextRenderer.MeasureText(g, file.Name, Font, bounds.Size, flags);
                float rem = bounds.Width - s.Width;
                if (rem > 3)
                {
                    bounds.Width = (int)rem;
                    Font = new Font(Font.FontFamily, Font.Size - 2, FontStyle.Italic);
                    TextRenderer.DrawText(g, file.DirectoryName, Font, bounds, Color.Black, flags);
                }
            }
        }

#endif
    }
}
