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

            // library_animations
            animation animationMain = new animation() { id="animationMain_ID", name="animationMain" };
            animations.animation = new animation[] { animationMain };

            List<object> listAnimationSource = new List<object>();


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
            uint caseIndex = 0;
            foreach (BoxLayer layer in _palletSolution)
                foreach (BoxPosition bp in layer)
                {
                    Vector3D translation = bp.Position;
                    Vector3D rotations = bp.Transformation.Rotations;

                    node caseNode = new node()
                    {
                        id = string.Format("CaseNode_{0}_ID", caseIndex),
                        name = string.Format("CaseNode_{0}", caseIndex),
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
                                sid = "t",
                            },
                            new rotate()
                            {
                                Values = new double[] { 1.0, 0.0, 0.0, rotations.X },
                                sid = "rx"
                            },
                            new rotate()
                            {
                                Values = new double[] { 0.0, 1.0, 0.0, rotations.Y },
                                sid = "ry"
                            },
                            new rotate()
                            {
                                Values = new double[] { 0.0, 0.0, 1.0, rotations.Z },
                                sid = "rz"
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
                                        new instance_material() { symbol="materialCase0", target="#material_Case0_ID" },
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

                    // animations
                    CreateAnimation(caseIndex, (uint)_palletSolution.CaseCount, listAnimationSource, bp);

                    // increment case index
                    ++caseIndex;
                }

            // add nodes
            mainScene.node = sceneNodes.ToArray();

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
            model.Save(System.IO.Path.ChangeExtension(filePath, "xml"));
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
                                        Item = new common_color_or_texture_typeColor() { Values = new double[] { 0.300000, 0.300000, 0.300000, 1.000000 } }
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
                                        Item = new common_color_or_texture_typeColor() { Values = new double[] { 0.900000, 0.900000, 0.900000, 1.000000 } }
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
                                        Item = new common_float_or_param_typeFloat() { Value = 25.00000 }
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

        #region Animations
        public void CreateAnimation(uint caseIndex, uint caseCount, List<object> listAnimationObjects, BoxPosition bPos)
        {
            const int iStep = 5;

            // build list of time
            List<double> listTime = new List<double>();
            List<string> listInterp = new List<string>();
            listTime.Add(0.0);
            listInterp.Add("LINEAR");
            for (int i = 0; i < iStep; ++i)
            {
                listTime.Add(((double)caseIndex + (double)i / (double)(iStep - 1)) );
                listInterp.Add("LINEAR");
            }
            listTime.Add(caseCount);
            listInterp.Add("LINEAR");

            BProperties bProperties = _palletSolution.Analysis.BProperties;
            PalletProperties pProperties = _palletSolution.Analysis.PalletProperties;


            double yOffset = 0.5 * (_palletSolution.Analysis.PalletProperties.Width - bProperties.Length);
            BoxPosition bPosFinal = GetFinalBoxPosition(caseIndex);


            List<BoxPosition> listBoxPosition = new List<BoxPosition>();
            // -1.
            listBoxPosition.Add(GetInitialBoxPosition(caseIndex));
            // 0. initialbox position
            listBoxPosition.Add(GetInitialBoxPosition(caseIndex));
            // 1. position at out storing area
            listBoxPosition.Add(new BoxPosition(new Vector3D(_xOffset, yOffset, _zOffset), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N));
            // 2. position above pallet
            listBoxPosition.Add(new BoxPosition(new Vector3D(pProperties.Length * 0.5, pProperties.Width * 0.5, _zOffset), bPosFinal.DirectionLength, bPosFinal.DirectionWidth));
            // 3. position above final position
            listBoxPosition.Add(new BoxPosition(new Vector3D(bPosFinal.Position.X, bPosFinal.Position.Y, _zOffset), bPosFinal.DirectionLength, bPosFinal.DirectionWidth));
            // 4. final position
            listBoxPosition.Add(bPosFinal);
            // 5.
            listBoxPosition.Add(bPosFinal);

            List<double> listX = new List<double>();
            List<double> listY = new List<double>();
            List<double> listZ = new List<double>();
            List<double> listRX = new List<double>();
            List<double> listRY = new List<double>();
            List<double> listRZ = new List<double>();

            BoxPosition bPprev0 = listBoxPosition[0];
            listX.Add(bPprev0.Position.X);
            listY.Add(bPprev0.Position.Y);
            listZ.Add(bPprev0.Position.Z);
            Vector3D vRotPrev0 = bPprev0.Transformation.Rotations;
            listRX.Add(vRotPrev0.X);
            listRY.Add(vRotPrev0.Y);
            listRZ.Add(vRotPrev0.Z);

            for (int i=1; i< listBoxPosition.Count; ++i)
            {
                BoxPosition bP = listBoxPosition[i];
                listX.Add(bP.Position.X);
                listY.Add(bP.Position.Y);
                listZ.Add(bP.Position.Z);
                Vector3D vRot = bP.Transformation.Rotations;
                listRX.Add(vRot.X);
                listRY.Add(vRot.Y);
                listRZ.Add(vRot.Z);
            }

            // time
            source sTime = new source()
            {
                id = string.Format("sTime_{0}_ID", caseIndex),
                name = string.Format("sTime_{0}", caseIndex),
                Item = new float_array()
                {
                    id = string.Format("fa_time_{0}_ID", caseIndex),
                    count = (ulong)listTime.Count,
                    Values = listTime.ToArray()
                },
                technique_common = new sourceTechnique_common()
                {
                    accessor = new accessor()
                    {
                        source = string.Format("#fa_time_{0}_ID", caseIndex),
                        count = (ulong)listTime.Count,
                        stride = 1,
                        param = new param[]
                        {
                            new param() { name="TIME", type="float" }
                        }
                    }
                }
            };
            listAnimationObjects.Add(sTime);

            // interp
            source sInterp = new source()
            {
                id = string.Format("sInterp_{0}_ID", caseIndex),
                name = string.Format("sInterp_{0}", caseIndex),
                Item = new Name_array()
                {
                    id = string.Format("na_interp_{0}_ID", caseIndex),
                    count = (ulong)listInterp.Count,
                    Values = listInterp.ToArray()
                },
                technique_common = new sourceTechnique_common()
                {
                    accessor = new accessor()
                    {
                        source = string.Format("#na_interp_{0}_ID", caseIndex),
                        count = (ulong)listInterp.Count,
                        stride = 1,
                        param = new param[]
                        {
                            new param() { name="INTERPOLATION", type="name" }
                        }
                    }
                }
            };
            listAnimationObjects.Add(sInterp);
            
            CreateChannel(listAnimationObjects, caseIndex, "X", "TIME", string.Format("CaseNode_{0}_ID/t.X", caseIndex), listX);
            CreateChannel(listAnimationObjects, caseIndex, "Y", "TIME", string.Format("CaseNode_{0}_ID/t.Y", caseIndex), listY);
            CreateChannel(listAnimationObjects, caseIndex, "Z", "TIME", string.Format("CaseNode_{0}_ID/t.Z", caseIndex), listZ);
            CreateChannel(listAnimationObjects, caseIndex, "RX", "ANGLE", string.Format("CaseNode_{0}_ID/rx.ANGLE", caseIndex), listRX);
            CreateChannel(listAnimationObjects, caseIndex, "RY", "ANGLE", string.Format("CaseNode_{0}_ID/ry.ANGLE", caseIndex), listRY);
            CreateChannel(listAnimationObjects, caseIndex, "RZ", "ANGLE", string.Format("CaseNode_{0}_ID/rz.ANGLE", caseIndex), listRZ);
             
        }

        protected BoxPosition GetInitialBoxPosition(uint caseIndex)
        {            
            uint iLayer = 0, iCounted = 0;
            foreach (BoxLayer layer in _palletSolution)
            {
                if (iCounted + layer.BoxCount > caseIndex)
                    break;
                else
                {
                    ++iLayer;
                    iCounted += (uint)layer.Count;
                }
            }

            BProperties bProperties = _palletSolution.Analysis.BProperties;

            double yOffset = 0.5 * (_palletSolution.Analysis.PalletProperties.Width - bProperties.Length);
            Vector3D vPosition = new Vector3D(_xOffset + (caseIndex - iCounted) * bProperties.Width, yOffset, (_palletSolution.Count-1-iLayer) * bProperties.Height);
            return new BoxPosition(vPosition, HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
        }

        protected BoxPosition GetFinalBoxPosition(uint caseIndex)
        {
            int iCounted = 0;
            int iLayer = 0;
            foreach (BoxLayer layer in _palletSolution)
            {
                if (iCounted + layer.BoxCount > caseIndex)
                    break;
                else
                {
                    ++iLayer;
                    iCounted += layer.Count;
                }
            }
            BoxLayer layerW = _palletSolution[iLayer] as BoxLayer;

            return layerW[(int)caseIndex - iCounted];
        }

        protected void CreateChannel(List<object> listAnimationObjects, uint caseIndex, string sData, string sDataType, string sTarget, List<double> lValues)
        {
            string sTime = string.Format("sTime_{0}_ID", caseIndex);
            string sInterp = string.Format("sInterp_{0}_ID", caseIndex);

            // source
            source source_ = new source()
            {
                id = string.Format("sValue_{0}_{1}_ID", caseIndex, sData),
                name = string.Format("sValue_{0}_{1}", caseIndex, sData),
                Item = new float_array() { id = string.Format("fa_{0}_{1}_ID", caseIndex, sData), count = (ulong)lValues.Count, Values = lValues.ToArray() },
                technique_common = new sourceTechnique_common()
                {
                    accessor = new accessor()
                    {
                        source = string.Format("#fa_{0}_{1}_ID", caseIndex, sData),
                        count = (ulong)lValues.Count,
                        stride = 1,
                        param = new param[]
                        {
                            new param() { name=sDataType, type="float" }
                        }
                    }
                }
            };
            listAnimationObjects.Add(source_);

            // sampler
            sampler sampler_ = new sampler()
            {
                id = string.Format("sampler_{0}_{1}_ID", caseIndex, sData),
                input = new InputLocal[]
                {
                    new InputLocal() { semantic="INPUT", source="#" + sTime },
                    new InputLocal() { semantic="OUTPUT", source="#" + source_.id },
                    new InputLocal() { semantic="INTERPOLATION", source="#" + sInterp }
                }
            };
            listAnimationObjects.Add(sampler_);

            // channel
            channel channel_ = new channel()
            {
                source= "#" + sampler_.id,
                target = sTarget
            };
            listAnimationObjects.Add(channel_);
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
        private double _xOffset = 2000.0;
        private double _zOffset = 2000.0;
        #endregion
    }
}
