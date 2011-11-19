using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GLib.Options
{
    [
    TypeConverter(typeof(ExpandableObjectConverter))
    ]
    [ToolboxItem(true)]
    public partial class OptionsPanel : UserControl
    {
        protected OptionsForm _OptionsForm;
        private String _Path;
        private String _DisplayName;

        private bool _OptionsUpdated;

        [Browsable(true)]
        [Description("This event is fired when the panel options are changed")]
        public event EventHandler OptionsChanged;

        #region Properties
        /// <summary>
        /// Gets the options form.
        /// </summary>
        /// <value>The options form.</value>
        [Browsable(false)]
        public OptionsForm OptionsForm
        {
            get
            {
                return _OptionsForm;
            }
        }

        [Category("Options Form")]
        [Description("The path of the OptionsPanel (determines the location in the Category TreeView in the parent OptionsForm form)")]
        public String CategoryPath
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }

        [Category("Options Form")]
        [Description("The name displayed for this panel in the Category TreeView in the parent OptionsForm form")]
        public String DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                _DisplayName = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether application must restart.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if application must restart to apply options otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool ApplicationMustRestart
        {
            get
            {
                if (OptionsForm != null)
                {
                    return OptionsForm.ApplicationMustRestart;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (OptionsForm != null)
                {
                    OptionsForm.ApplicationMustRestart = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [options changed].
        /// </summary>
        /// <value><c>true</c> if [options changed]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool OptionsUpdated
        {
            get
            {
                return _OptionsUpdated;
            }
            set
            {
                _OptionsUpdated = value;

                if (_OptionsUpdated)
                {
                    OnOptionsChanged();
                }
            }
        }

        #endregion

        public OptionsPanel()
        {
            InitializeComponent();
        }

        virtual public void PanelAdded(OptionsForm optf)
        {
            _OptionsForm = optf;

            InitPanelForControl(this);

            _OptionsForm.OptionsSaving += new EventHandler(OptionsSaving);
            _OptionsForm.OptionsSaved += new EventHandler(OptionsSaved);
            _OptionsForm.ResetForm += new EventHandler(ResetForm);
        }

        protected void SetOption(String OptionName, Object value)
        {
            _OptionsForm.AppSettings[OptionName] = value;
            OptionsUpdated = true;
        }

        protected void OnOptionsChanged()
        {
            if (OptionsChanged != null)
            {
                OptionsChanged(this, EventArgs.Empty);
            }
        }

        protected void OptionsSaving(object sender, EventArgs e)
        {
        }

        protected void OptionsSaved(object sender, EventArgs e)
        {
            ReloadValues(this);
        }

        protected virtual void ResetForm(object sender, EventArgs e)
        {
            ReloadValues(this);
        }
        
        private void ReloadValues(Control ctrl)
        {
            for (int i = 0; i < ctrl.Controls.Count; i++)
            {
                Control ctrl2 = ctrl.Controls[i];

                for (int l = 0; l < ctrl2.DataBindings.Count; l++)
                {
                    Binding bind = ctrl2.DataBindings[l];
                    bind.ReadValue();
                }

                ReloadValues(ctrl2);
            }
        }

        private void InitPanelForControl(Control ctrl)
        {
            for (int i = 0; i < ctrl.Controls.Count; i++)
            {
                Control ctrl2 = ctrl.Controls[i];

                for (int l = 0; l < ctrl2.DataBindings.Count; l++)
                {
                    Binding bind = ctrl2.DataBindings[l];
                    String prop = bind.BindingMemberInfo.BindingMember;

                    try
                    {
                        Object value = _OptionsForm.AppSettings[prop];

                        if (value != null)
                        {
                            bind.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                            bind.ControlUpdateMode = ControlUpdateMode.Never;
                            System.Configuration.SettingsProperty sett = new System.Configuration.SettingsProperty(prop);
                            sett.DefaultValue = value;
                            _OptionsForm.Settings.Add(sett);
                        }
                    }
                    catch
                    {
                    }
                }

                InitPanelForControl(ctrl2);
            }
        }
    }
}
