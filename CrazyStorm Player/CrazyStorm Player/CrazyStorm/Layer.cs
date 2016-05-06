﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CrazyStorm_Player.CrazyStorm
{
    class Layer : IPlayData
    {
        public string Name { get; set; }
        public bool Visible { get; set; }
        public int BeginFrame { get; set; }
        public int TotalFrame { get; set; }
        public IList<Component> Components { get; private set; }
        public Layer()
        {
            Components = new List<Component>();
        }
        public void LoadPlayData(BinaryReader reader)
        {
            using (BinaryReader layerReader = PlayDataHelper.GetBlockReader(reader))
            {
                Name = PlayDataHelper.ReadString(layerReader);
                Visible = layerReader.ReadBoolean();
                BeginFrame = layerReader.ReadInt32();
                TotalFrame = layerReader.ReadInt32();
                //components
                using (BinaryReader componentsReader = PlayDataHelper.GetBlockReader(layerReader))
                {
                    while (!PlayDataHelper.EndOfReader(componentsReader))
                    {
                        long startPosition = componentsReader.BaseStream.Position;
                        using (BinaryReader componentReader = PlayDataHelper.GetBlockReader(componentsReader))
                        {
                            Component component = null;
                            switch (PlayDataHelper.ReadString(componentReader))
                            {
                                case "MultiEmitter":
                                    component = new MultiEmitter();
                                    break;
                                case "CurveEmitter":
                                    component = new CurveEmitter();
                                    break;
                                case "EventField":
                                    component = new EventField();
                                    break;
                                case "Rebounder":
                                    component = new Rebounder();
                                    break;
                                case "ForceField":
                                    component = new ForceField();
                                    break;
                            }
                            //Back to start position of components block.
                            componentsReader.BaseStream.Position = startPosition;
                            component.LoadPlayData(componentsReader);
                            Components.Add(component);
                        }
                    }
                }
            }
        }
    }
}
