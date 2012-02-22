#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;

using Collada141;
#endregion

namespace TreeDim.StackBuilder.ColladaExporter
{
    public class Exporter
    {
        #region Constructor
        public Exporter(PalletSolution palletSolution)
        {
            _palletSolution = palletSolution;
        }
        #endregion

        #region Export
        public void Export(string filePath)
        {
            PalletProperties palletProperties = _palletSolution.Analysis.PalletProperties;

            COLLADA model = new COLLADA();
            // asset
            model.asset = new asset()
            {
                created = DateTime.Now,
                modified = DateTime.Now
            };
            model.asset.keywords = "StackBuilder Pallet Case";
            model.asset.title = _palletSolution.Title;
            model.asset.unit = new assetUnit() { name = "millimeters", meter = 0.001 };
            model.asset.up_axis = UpAxisType.Z_UP;

            library_images images = new library_images();
            library_materials materials = new library_materials();
            library_effects effects = new library_effects();
            library_geometries geometries = new library_geometries();
            library_nodes nodes = new library_nodes();
            library_cameras cameras = new library_cameras();
            library_animations animations = new library_animations();
            library_visual_scenes scenes = new library_visual_scenes();

            COLLADAScene colladaScene = new COLLADAScene();

            model.Items = new Object[] { images, materials, effects, geometries, nodes, cameras, animations, scenes };
            model.scene = colladaScene;

            // colors and materials
            List<effect> listEffects = new List<effect>();
            List<material> listMaterials = new List<material>();

            // effects
            effect effectPallet;
            material materialPallet;
            CreateMaterial(palletProperties.Color, "Pallet", out effectPallet, out materialPallet);
            listEffects.Add(effectPallet);
            listMaterials.Add(materialPallet);

            Box box = new Box(0, _palletSolution.Analysis.BProperties);
            uint colorIndex = 0;
            foreach (Color col in box.Colors)
            {
                material materialCase;
                effect effectCase;
                CreateMaterial(col, string.Format("Case{0}", colorIndex), out effectCase, out materialCase);

                listEffects.Add(effectCase);
                listMaterials.Add(materialCase);

                ++colorIndex;
            }

            // case lines material
            effect effectCaseLines;
            material materialCaseLines;
            CreateMaterial(Color.Black, "CaseLines", out effectCaseLines, out materialCaseLines);
            listEffects.Add(effectCaseLines);
            listMaterials.Add(materialCaseLines);


            effects.effect = listEffects.ToArray();
            materials.material = listMaterials.ToArray();

            // geometries
            geometry geomPallet = new geometry() { id = "palletGeometry", name = "palletGeometry" };
            geometry geomCase = new geometry() { id = "caseGeometry", name = "caseGeometry" };
            geometries.geometry = new geometry[] { geomPallet, geomCase };
            // pallet
            mesh meshPallet = CreatePalletMesh(palletProperties);
            geomPallet.Item = meshPallet;
            // case
            mesh meshCase = CreateCaseMesh(_palletSolution.Analysis.BProperties as BoxProperties);
            geomCase.Item = meshCase;

            // library_visual_scenes
            visual_scene mainScene = new visual_scene() { id = "MainScene", name = "MainScene" };
            scenes.visual_scene = new visual_scene[] { mainScene };

            List<node> sceneNodes = new List<node>();
            sceneNodes.Add(new node()
            {
                id = "PalletNode",
                name = "PalletNode",
                instance_geometry = new instance_geometry[]
                {
                    new instance_geometry()
                    {
                        url = "#palletGeometry",
                        bind_material = new bind_material()
                        {
                            technique_common = new instance_material[]
                            {
                                new instance_material()
                                {
                                    symbol="materialPallet",
                                    target=string.Format("#{0}", materialPallet.id)
                                }
                            }
                        }
                    }
                }
            });
            uint i = 0;
            foreach (BoxLayer layer in _palletSolution)
                foreach (BoxPosition bp in layer)
                {
                    Vector3D translation = bp.Position;
                    Vector3D rotations = bp.Transformation.Rotations;

                    node caseNode = new node()
                    {
                        id = string.Format("CaseNode_{0}_ID", i),
                        name = string.Format("CaseNode_{0}", i),
                        ItemsElementName = new ItemsChoiceType2[]
                        {
                            ItemsChoiceType2.translate,
                            ItemsChoiceType2.rotate,
                            ItemsChoiceType2.rotate,
                            ItemsChoiceType2.rotate
                        },
                        Items = new object[]
                        {
                            new TargetableFloat3()
                            {
                                Values = new double[] { translation.X, translation.Y, translation.Z },
                                sid = string.Format("NodeCase{0}_trans", i),
                            },
                            new rotate()
                            {
                                Values = new double[] { 1.0, 0.0, 0.0, rotations.X },
                                sid = string.Format("NodeCase{0}_rotateX", i)
                            },
                            new rotate()
                            {
                                Values = new double[] { 0.0, 1.0, 0.0, rotations.Y },
                                sid = string.Format("NodeCase{0}_rotateY", i)
                            },
                            new rotate()
                            {
                                Values = new double[] { 0.0, 0.0, 1.0, rotations.Z },
                                sid = string.Format("NodeCase{0}_rotateZ", i)
                            } 
                     },

                        instance_geometry = new instance_geometry[]
                        {
                            new instance_geometry()
                            {
                                url="#caseGeometry",
                                bind_material = new bind_material()
                                {
                                    technique_common = new instance_material[]
                                    {
                                        new instance_material() { symbol="materialCase", target="#material_Case0_ID" },
                                        new instance_material() { symbol="materialCase1", target="#material_Case1_ID" },
                                        new instance_material() { symbol="materialCase2", target="#material_Case2_ID" },
                                        new instance_material() { symbol="materialCase3", target="#material_Case3_ID" },
                                        new instance_material() { symbol="materialCase4", target="#material_Case4_ID" },
                                        new instance_material() { symbol="materialCase5", target="#material_Case5_ID" },
                                        new instance_material() { symbol="materialCaseLines", target="#material_CaseLines_ID"}
                                    }
                                }
                            }
                        }
                    };
                    sceneNodes.Add(caseNode);
                    ++i;
                }

            // add nodes
            mainScene.node = sceneNodes.ToArray();

            // library_animations
            animation animationMain = new animation() { id="animationMain_ID", name="animationMain",  };
            animations.animation = new animation[] { animationMain };

            List<object> listAnimationSource = new List<object>();
            source sTime = new source() { id = "animationTime_ID", name = "animationTime" };
            sTime.Item = new float_array() { id = "animationTime_floatarray", count = 4, Values = new double[] { 0.0, 0.333333, 0.66666, 1.0 } };
            sTime.technique_common = new sourceTechnique_common() { };
            listAnimationSource.Add(sTime);
            animationMain.Items = listAnimationSource.ToArray();

            // library_cameras
            camera cameraCamera = new camera() { id = "Camera-Camera", name = "Camera-Camera" };
            cameraOpticsTechnique_commonPerspective cameraPerspective = new cameraOpticsTechnique_commonPerspective()
            {
                znear = new TargetableFloat() { sid = "znear", Value = 1.0 },
                zfar = new TargetableFloat() { sid = "zfar", Value = 10000.0 }
            };
            cameraCamera.optics = new cameraOptics() { technique_common = new cameraOpticsTechnique_common() { Item = cameraPerspective } };
            cameras.camera = new camera[] { cameraCamera };

            // colladaScene
            colladaScene.instance_visual_scene = new InstanceWithExtra() { url = "#MainScene" };

            model.Save(filePath);
        }
        #endregion

        #region Material
        protected void CreateMaterial(Color color, string material, out effect effectColor, out material materialColor)
        {
            string effect_ID = string.Format("effect_{0}_ID", material);
            string effectName = string.Format("effect_{0}", material);
            string materialID = string.Empty;
            effectColor = new effect()
            {
                id = string.Format("effect_{0}_ID", material),
                name = string.Format("effect_{0}", material),
                Items = new effectFx_profile_abstractProfile_COMMON[]
                    {
                        new effectFx_profile_abstractProfile_COMMON()
                        {
                            technique = new effectFx_profile_abstractProfile_COMMONTechnique()
                            {
                                Item = new effectFx_profile_abstractProfile_COMMONTechniquePhong()
                                {
                                    ambient = new common_color_or_texture_type()
                                    {
                                        Item = new common_color_or_texture_typeColor() { Values = new double[] { 0.050000, 0.050000, 0.050000, 1.000000 } }
                                    },
                                    emission = new common_color_or_texture_type()
                                    {
                                        Item = new common_color_or_texture_typeColor() { Values = new double[] { 0.050000, 0.050000, 0.050000, 1.000000 } }
                                    },
                                    diffuse = new common_color_or_texture_type()
                                    {
                                        Item = new common_color_or_texture_typeColor() { Values = new double[] { (double)color.R / 255.0, (double)color.G / 255.0, (double)color.B / 255.0, 1.000000 } }
                                    },
                                    specular = new common_color_or_texture_type()
                                    {
                                        Item = new common_color_or_texture_typeColor() { Values = new double[] { 0.050000, 0.050000, 0.050000, 1.000000 } }
                                    },
                                    transparent = new common_transparent_type()
                                    {
                                        Item = new common_color_or_texture_typeColor() { Values = new double[] { 1.000000, 1.000000, 1.000000, 1.000000 } }
                                    },
                                    reflectivity = new common_float_or_param_type()
                                    {
                                        Item = new common_float_or_param_typeFloat() { Value = 0.000000 }
                                    },
                                    shininess = new common_float_or_param_type()
                                    {
                                        Item = new common_float_or_param_typeFloat() { Value = 50.00000 }
                                    },
                                    transparency = new common_float_or_param_type()
                                    {
                                        Item = new common_float_or_param_typeFloat() { Value = 0.000000 }
                                    }
                                }
                            }
                        }
                    }
            };


            // materials
            materialColor = new material()
            {
                id = string.Format("material_{0}_ID", material),
                name = string.Format("material_{0}", material),
                instance_effect = new instance_effect()
                {
                    url = string.Format("#{0}", effectColor.id)
                }
            };
        }
        #endregion

        #region Case meshes
        protected mesh CreateCaseMesh(BoxProperties caseProperties)
        {
            // build box
            Box box = new Box(0, caseProperties);
            // build list of vertices / normals / UVs
            ulong vertexCount = 0, normalCount = 0, uvCount = 0;
            List<double> doubleArrayPosition = new List<double>(), doubleArrayNormal = new List<double>(), doubleArrayUV = new List<double>();
            foreach (Vector3D p in box.Points)
            {
                doubleArrayPosition.Add(p.X); doubleArrayPosition.Add(p.Y); doubleArrayPosition.Add(p.Z);
                ++vertexCount;
            }
            foreach (Vector3D n in box.Normals)
            {
                doubleArrayNormal.Add(n.X); doubleArrayNormal.Add(n.Y); doubleArrayNormal.Add(n.Z);
                ++normalCount;
            }
            foreach (Vector2D uv in box.UVs)
            {
                doubleArrayUV.Add(uv.X); doubleArrayUV.Add(uv.Y);
                ++uvCount;
            }

            mesh caseMesh = new mesh();

            // position source
            source casePositionSource = new source() { id = "case_position", name = "case_position" };
            float_array farrayPosition = new float_array { id = "case_position_float_array", count = (ulong)doubleArrayPosition.Count, Values = doubleArrayPosition.ToArray() };
            casePositionSource.technique_common = new sourceTechnique_common()
            {
                accessor = new accessor()
                {
                    stride = 3,
                    count = vertexCount,
                    source = "#case_position_float_array",
                    param = new param[] { new param() { name = "X", type = "float" }, new param() { name = "Y", type = "float" }, new param() { name = "Z", type = "float" } }
                }
            };
            casePositionSource.Item = farrayPosition;

            // normal source
            source casePositionNormal = new source() { id = "case_normal", name = "case_normal" };
            float_array farrayNormal = new float_array { id = "case_normal_float_array", count = (ulong)doubleArrayNormal.Count, Values = doubleArrayNormal.ToArray() };
            casePositionNormal.technique_common = new sourceTechnique_common()
            {
                accessor = new accessor()
                {
                    stride = 3,
                    count = normalCount,
                    source = "#case_normal_float_array",
                    param = new param[] { new param() { name = "X", type = "float" }, new param() { name = "Y", type = "float" }, new param() { name = "Z", type = "float" } }
                }
            };
            casePositionNormal.Item = farrayNormal;

            // uv source
            source casePositionUV = new source() { id = "case_UV", name = "pallet_UV" };
            float_array farrayUV = new float_array { id = "case_UV_float_array", count = (ulong)doubleArrayUV.Count, Values = doubleArrayUV.ToArray() };
            casePositionUV.technique_common = new sourceTechnique_common()
            {
                accessor = new accessor()
                {
                    stride = 2,
                    count = vertexCount,
                    source = "#case_UV_float_array",
                    param = new param[] { new param() { name = "S", type = "float" }, new param() { name = "T", type = "float" } }
                }
            };
            casePositionUV.Item = farrayUV;
            // insert sources
            caseMesh.source = new source[] { casePositionSource, casePositionNormal, casePositionUV };

            // vertices
            InputLocal verticesInput = new InputLocal() { semantic = "POSITION", source = "#case_position" };
            caseMesh.vertices = new vertices() { id = "case_vertex", input = new InputLocal[] { verticesInput } };

            List<object> trianglesList = new List<object>();

            // build list of triangles
            foreach (HalfAxis.HAxis axis in HalfAxis.All)
            {
                triangles trianglesCase = new triangles() { material = string.Format("materialCase{0}", (uint)axis), count = 2 };
                trianglesCase.input = new InputLocalOffset[]
                                    {
                                        new InputLocalOffset() { semantic="VERTEX", source="#case_vertex", offset=0}
                                        , new InputLocalOffset() { semantic="NORMAL", source="#case_normal", offset=1}
                                        , new InputLocalOffset() { semantic="TEXCOORD", source="#case_UV", offset=2, set=0, setSpecified=true }
                                    };
                string triangle_string = string.Empty;
                foreach (TriangleIndices tr in box.TrianglesByFace(axis))
                    triangle_string += tr.ConvertToString(0);
                trianglesCase.p = triangle_string;
                trianglesList.Add(trianglesCase);
            }
            // build list of lines
            lines linesCase = new lines()
            {
                material = "materialCaseLines",
                count = 12,
                input = new InputLocalOffset[]
                {
                    new InputLocalOffset() { semantic="VERTEX", source="#case_vertex", offset=0}
                },
                p = "0 1 1 2 2 3 3 0 4 5 5 6 6 7 7 4 0 4 1 5 2 6 3 7"
            };
            trianglesList.Add(linesCase);

            caseMesh.Items = trianglesList.ToArray();
            return caseMesh;
        }
        #endregion

        #region Pallet mesh
        protected mesh CreatePalletMesh(PalletProperties palletProperties)
        {
            // build pallet object
            Pallet pallet = new Pallet(palletProperties);
            // build list of boxes
            List<Box> listBoxes = pallet.BuildListOfBoxes();
            // build list of vertices / normals / UVs
            ulong vertexCount = 0, normalCount = 0, uvCount = 0, triangleCount = 0, boxCount = 0;
            string triangle_string = string.Empty;

            List<double> doubleArrayPosition = new List<double>(), doubleArrayNormal = new List<double>(), doubleArrayUV = new List<double>();

            foreach (Box box in listBoxes)
            {
                foreach (Vector3D p in box.Points)
                {
                    doubleArrayPosition.Add(p.X); doubleArrayPosition.Add(p.Y); doubleArrayPosition.Add(p.Z);
                    ++vertexCount;
                }
                foreach (Vector3D n in box.Normals)
                {
                    doubleArrayNormal.Add(n.X); doubleArrayNormal.Add(n.Y); doubleArrayNormal.Add(n.Z);
                    ++normalCount;
                }
                foreach (Vector2D uv in box.UVs)
                {
                    doubleArrayUV.Add(uv.X); doubleArrayUV.Add(uv.Y);
                    ++uvCount;
                }
                foreach (TriangleIndices tr in box.Triangles)
                {
                    triangle_string += tr.ConvertToString(boxCount);
                    ++triangleCount;
                }
                ++boxCount;
            }
            mesh palletMesh = new mesh();

            // position source
            source palletPositionSource = new source() { id = "pallet_position", name = "pallet_position" };
            float_array farrayPosition = new float_array { id = "pallet_position_float_array", count = (ulong)doubleArrayPosition.Count, Values = doubleArrayPosition.ToArray() };
            palletPositionSource.technique_common = new sourceTechnique_common()
            {
                accessor = new accessor()
                {
                    stride = 3,
                    count = vertexCount,
                    source = "#pallet_position_float_array",
                    param = new param[] { new param() { name = "X", type = "float" }, new param() { name = "Y", type = "float" }, new param() { name = "Z", type = "float" } }
                }
            };
            palletPositionSource.Item = farrayPosition;

            // normal source
            source palletPositionNormal = new source() { id = "pallet_normal", name = "pallet_normal" };
            float_array farrayNormal = new float_array { id = "pallet_normal_float_array", count = (ulong)doubleArrayNormal.Count, Values = doubleArrayNormal.ToArray() };
            palletPositionNormal.technique_common = new sourceTechnique_common()
            {
                accessor = new accessor()
                {
                    stride = 3,
                    count = normalCount,
                    source = "#pallet_normal_float_array",
                    param = new param[] { new param() { name = "X", type = "float" }, new param() { name = "Y", type = "float" }, new param() { name = "Z", type = "float" } }
                }
            };
            palletPositionNormal.Item = farrayNormal;

            // uv source
            source palletPositionUV = new source() { id = "pallet_UV", name = "pallet_UV" };
            float_array farrayUV = new float_array { id = "pallet_UV_float_array", count = (ulong)doubleArrayUV.Count, Values = doubleArrayUV.ToArray() };
            palletPositionUV.technique_common = new sourceTechnique_common()
            {
                accessor = new accessor()
                {
                    stride = 2,
                    count = vertexCount,
                    source = "#pallet_UV_float_array",
                    param = new param[] { new param() { name = "S", type = "float" }, new param() { name = "T", type = "float" } }
                }
            };
            palletPositionUV.Item = farrayUV;
            // insert sources
            palletMesh.source = new source[] { palletPositionSource, palletPositionNormal, palletPositionUV };

            // vertices
            InputLocal verticesInput = new InputLocal() { semantic = "POSITION", source = "#pallet_position" };
            palletMesh.vertices = new vertices() { id = "pallet_vertex", input = new InputLocal[] { verticesInput } };

            triangles trianglesPallet = new triangles() { material = "materialPallet", count = triangleCount };
            trianglesPallet.input = new InputLocalOffset[]
                                    {
                                        new InputLocalOffset() { semantic="VERTEX", source="#pallet_vertex", offset=0}
                                        , new InputLocalOffset() { semantic="NORMAL", source="#pallet_normal", offset=1}
                                        , new InputLocalOffset() { semantic="TEXCOORD", source="#pallet_UV", offset=2, set=0, setSpecified=true }
                                    };

            trianglesPallet.p = triangle_string;
            palletMesh.Items = new object[] { trianglesPallet };

            return palletMesh;
        }
        #endregion

        #region Data members
        private PalletSolution _palletSolution;
        #endregion
    }
}
