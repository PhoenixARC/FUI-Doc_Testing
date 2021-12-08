using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FUI_Doc_Testing
{
    public class FourJUserInterface
    {

        public class FUI
        {
            public Header header = new Header();
            public List<Timeline> timelines = new List<Timeline>();
            public List<TimelineAction> timelineActions = new List<TimelineAction>();
            public List<Shape> shapes = new List<Shape>();
            public List<ShapeComponent> shapeComponents = new List<ShapeComponent>();
            public List<Vert> verts = new List<Vert>();
            public List<TimelineFrame> timelineFrames = new List<TimelineFrame>();
            public List<TimelineEvent> timelineEvents = new List<TimelineEvent>();
            public List<TimelineEventName> timelineEventNames = new List<TimelineEventName>();
            public List<Reference> references = new List<Reference>();
            public List<Edittext> edittexts = new List<Edittext>();
            public List<FontName> fontNames = new List<FontName>();
            public List<Symbol> symbols = new List<Symbol>();
            public List<ImportAsset> importAssets = new List<ImportAsset>();
            public List<Bitmap> bitmaps = new List<Bitmap>();
            public List<byte[]> Images = new List<byte[]>();
        }

        #region FuiComponents

        //fuiHeader	0x98
        public class Header
        {
            public string Identifier;
            public int Unknow;
            public int ContentSize;
            public string SwfFileName;
            public int fuiTimelineCount;
            public int fuiTimelineEventNameCount;
            public int fuiTimelineActionCount;
            public int fuiShapeCount;
            public int fuiShapeComponentCount;
            public int fuiVertCount;
            public int fuiTimelineFrameCount;
            public int fuiTimelineEventCount;
            public int fuiReferenceCount;
            public int fuiEdittextCount;
            public int fuiSymbolCount;
            public int fuiBitmapCount;
            public int imagesSize;
            public int fuiFontNameCount;
            public int fuiImportAssetCount;
            public byte[] FrameSize;
        }

        //fuiTimeline	0x1c
        public class Timeline
        {
            public int ObjectType;
            public byte[] Unknown;
            public byte[] Rectangle;
        }

        //fuiTimelineAction	0x84
        public class TimelineAction
        {
            public byte[] Unknown;
            public string UnknownName1;
            public string UnknownName2;
        }

        //fuiShape	0x1c
        public class Shape
        {
            public int UnknownValue1;
            public int UnknownValue2;
            public int ObjectType;
            public byte[] Rectangle;
        }

        //fuiShapeComponent	0x2c
        public class ShapeComponent
        {
            public byte[] FillInfo;
            public int UnknownValue1;
            public int UnknownValue2;
        }

        //fuiVert	0x8
        public class Vert
        {
            public int x;
            public int y;
        }

        //fuiTimelineFrame	0x48
        public class TimelineFrame
        {
            public string FrameName;
            public int Unknown1;
            public int Unknown2;
        }

        //fuiTimelineEvent	0x48
        public class TimelineEvent
        {
            public byte[] Unknown;
            public byte[] matrix;
            public byte[] ColorTransform;
            public byte[] Color;
        }

        //fuiTimelineEventName	0x40
        public class TimelineEventName
        {
            public string EventName;
        }

        //fuiReference	0x48
        public class Reference
        {
            public int Unknown1;
            public string ReferenceName;
            public byte[] Unknown2;
        }

        //fuiEdittext	0x138
        public class Edittext
        {
            public int Unknown1;
            public byte[] rectangle;
            public int Unknown2;
            public float Unknown3;
            public byte[] Color;
            public byte[] Unknown4;
            public string htmlTextFormat;
        }

        //fuiFontName	0x104
        public class FontName
        {
            public int Unknown1;
            public string Fontname;
            public int Unknown2;
            public string Unknown3;
            public byte[] Unknown4;
            public string Unknown5;
            public byte[] Unknown6;
            public string Unknown7;
        }

        //fuiSymbol	0x48
        public class Symbol
        {
            public string SymbolName;
            public int ObjectType;
            public int Unknown;
        }

        //fuiImportAsset	0x40
        public class ImportAsset
        {
            public string AssetName;
        }

        //fuiBitmap	0x20
        public class Bitmap
        {
            public int Unknown1;
            public int ObjectType;
            public int ScaleWidth;
            public int ScaleHeight;
            public int Size1;
            public int Size2;
            public int Unknown2;
            public int Unknown3;
        }

        #endregion

        public class Functions
        {
            public FUI fui2;

            int offset = (int)0x98;

            public void OpenFUI(string Path, FUI fjui)
            {

                fui2 = fjui;

                byte[] Data = File.ReadAllBytes(Path);
                ReadHeaders(Data.Skip(0).Take((int)0x98).ToArray());
                CheckTimelines(Data);
                CheckTimelineActions(Data);
                CheckShapes(Data);
                CheckShapeComponents(Data);
                CheckVerts(Data);
                CheckTimelineFrames(Data);
                CheckTimelineEvents(Data);
                CheckTimelineEventNames(Data);
                CheckReferences(Data);
                CheckEdittexts(Data);
                CheckFontNames(Data);
                CheckSymbols(Data);
                CheckImportAssets(Data);
                CheckBitmaps(Data);

                if (MessageBox.Show("Do you want to open FUI in viewer?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FUIView fv = new FUIView(fui2);
                    fv.ShowDialog();
                }
            }

            void ReadHeaders(byte[] Header)
            {

                byte[] Identifier = Header.Skip(0).Take(4).ToArray();
                byte[] Unknow = Header.Skip(4).Take(4).ToArray();
                byte[] ContentSize = Header.Skip(8).Take(4).ToArray();
                byte[] SwfFileName = Header.Skip((int)0xc).Take((int)0x40).ToArray();
                byte[] fuiTimelineCount = Header.Skip((int)0x4c).Take(4).ToArray();
                byte[] fuiTimelineEventNameCount = Header.Skip((int)0x50).Take(4).ToArray();
                byte[] fuiTimelineActionCount = Header.Skip((int)0x54).Take(4).ToArray();
                byte[] fuiShapeCount = Header.Skip((int)0x58).Take(4).ToArray();
                byte[] fuiShapeComponentCount = Header.Skip((int)0x5c).Take(4).ToArray();
                byte[] fuiVertCount = Header.Skip((int)0x60).Take(4).ToArray();
                byte[] fuiTimelineFrameCount = Header.Skip((int)0x64).Take(4).ToArray();
                byte[] fuiTimelineEventCount = Header.Skip((int)0x68).Take(4).ToArray();
                byte[] fuiReferenceCount = Header.Skip((int)0x6c).Take(4).ToArray();
                byte[] fuiEdittextCount = Header.Skip((int)0x70).Take(4).ToArray();
                byte[] fuiSymbolCount = Header.Skip((int)0x74).Take(4).ToArray();
                byte[] fuiBitmapCount = Header.Skip((int)0x78).Take(4).ToArray();
                byte[] imagesSize = Header.Skip((int)0x7c).Take(4).ToArray();
                byte[] fuiFontNameCount = Header.Skip((int)0x80).Take(4).ToArray();
                byte[] fuiImportAssetCount = Header.Skip((int)0x84).Take(4).ToArray();
                byte[] FrameSize = Header.Skip((int)0x88).Take((int)0x10).ToArray();


                fui2.header.Identifier = Encoding.Default.GetString(Identifier);
                fui2.header.Unknow = BitConverter.ToInt32(Unknow, 0);
                fui2.header.ContentSize = BitConverter.ToInt32(ContentSize, 0);
                fui2.header.SwfFileName = Encoding.Default.GetString(SwfFileName);
                fui2.header.fuiTimelineCount = BitConverter.ToInt32(fuiTimelineCount, 0);
                fui2.header.fuiTimelineEventNameCount = BitConverter.ToInt32(fuiTimelineEventNameCount, 0);
                fui2.header.fuiTimelineActionCount = BitConverter.ToInt32(fuiTimelineActionCount, 0);
                fui2.header.fuiShapeCount = BitConverter.ToInt32(fuiShapeCount, 0);
                fui2.header.fuiShapeComponentCount = BitConverter.ToInt32(fuiShapeComponentCount, 0);
                fui2.header.fuiVertCount = BitConverter.ToInt32(fuiVertCount, 0);
                fui2.header.fuiTimelineFrameCount = BitConverter.ToInt32(fuiTimelineFrameCount, 0);
                fui2.header.fuiTimelineEventCount = BitConverter.ToInt32(fuiTimelineEventCount, 0);
                fui2.header.fuiReferenceCount = BitConverter.ToInt32(fuiReferenceCount, 0);
                fui2.header.fuiEdittextCount = BitConverter.ToInt32(fuiEdittextCount, 0);
                fui2.header.fuiSymbolCount = BitConverter.ToInt32(fuiSymbolCount, 0);
                fui2.header.fuiBitmapCount = BitConverter.ToInt32(fuiBitmapCount, 0);
                fui2.header.imagesSize = BitConverter.ToInt32(imagesSize, 0);
                fui2.header.fuiFontNameCount = BitConverter.ToInt32(fuiFontNameCount, 0);
                fui2.header.fuiImportAssetCount = BitConverter.ToInt32(fuiImportAssetCount, 0);
                fui2.header.FrameSize = (FrameSize);


                Console.WriteLine(" *** HEADERS *** ");
                Console.WriteLine("Identifier - " + Encoding.Default.GetString(Identifier));
                Console.WriteLine("Unknow - " + BitConverter.ToInt32(Unknow, 0));
                Console.WriteLine("ContentSize - " + BitConverter.ToInt32(ContentSize, 0));
                Console.WriteLine("SwfFileName - " + Encoding.Default.GetString(SwfFileName));
                Console.WriteLine("fuiTimelineCount - " + BitConverter.ToInt32(fuiTimelineCount, 0));
                Console.WriteLine("fuiTimelineEventNameCount - " + BitConverter.ToInt32(fuiTimelineEventNameCount, 0));
                Console.WriteLine("fuiTimelineActionCount - " + BitConverter.ToInt32(fuiTimelineActionCount, 0));
                Console.WriteLine("fuiShapeCount - " + BitConverter.ToInt32(fuiShapeCount, 0));
                Console.WriteLine("fuiShapeComponentCount - " + BitConverter.ToInt32(fuiShapeComponentCount, 0));
                Console.WriteLine("fuiVertCount - " + BitConverter.ToInt32(fuiVertCount, 0));
                Console.WriteLine("fuiTimelineFrameCount - " + BitConverter.ToInt32(fuiTimelineFrameCount, 0));
                Console.WriteLine("fuiTimelineEventCount - " + BitConverter.ToInt32(fuiTimelineEventCount, 0));
                Console.WriteLine("fuiReferenceCount - " + BitConverter.ToInt32(fuiReferenceCount, 0));
                Console.WriteLine("fuiEdittextCount - " + BitConverter.ToInt32(fuiEdittextCount, 0));
                Console.WriteLine("fuiSymbolCount - " + BitConverter.ToInt32(fuiSymbolCount, 0));
                Console.WriteLine("fuiBitmapCount - " + BitConverter.ToInt32(fuiBitmapCount, 0));
                Console.WriteLine("imagesSize - " + BitConverter.ToInt32(imagesSize, 0));
                Console.WriteLine("fuiFontNameCount - " + BitConverter.ToInt32(fuiFontNameCount, 0));
                Console.WriteLine("fuiImportAssetCount - " + BitConverter.ToInt32(fuiImportAssetCount, 0));
                Console.WriteLine("FrameSize - " + BitConverter.ToString(FrameSize) + "");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                //rebuild
                List<byte> Output = new List<byte>();
                Output.AddRange(Encoding.UTF8.GetBytes(fui2.header.Identifier));
                Output.AddRange(BitConverter.GetBytes(fui2.header.Unknow));
                Output.AddRange(BitConverter.GetBytes(fui2.header.ContentSize));
                Output.AddRange(Encoding.UTF8.GetBytes(fui2.header.SwfFileName));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiTimelineCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiTimelineEventNameCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiTimelineActionCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiShapeCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiShapeComponentCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiVertCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiTimelineFrameCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiTimelineEventCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiReferenceCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiEdittextCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiSymbolCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiBitmapCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.imagesSize));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiFontNameCount));
                Output.AddRange(BitConverter.GetBytes(fui2.header.fuiImportAssetCount));
                Output.AddRange((fui2.header.FrameSize));

                if (BitConverter.ToString(Output.ToArray()) != BitConverter.ToString(Header))
                    throw new Exception();

            }

            void CheckTimelines(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiTimelineCount)
                {
                    FourJUserInterface.Timeline tl = new FourJUserInterface.Timeline();
                    tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                    tl.Unknown = Data.Skip(offset + 4).Take(8).ToArray();
                    tl.Rectangle = Data.Skip(offset + (int)0xc).Take((int)0x10).ToArray();
                    fui2.timelines.Add(tl);
                    offset += (int)0x1C;
                    i++;
                    

                    Console.WriteLine("Timeline -- ObjectType=" + tl.ObjectType);
                    Console.Write("Timeline -- Unknown={ ");
                    foreach (byte shr in tl.Unknown)
                        Console.Write(shr + ", ");
                    Console.Write("}");
                    Console.WriteLine("");
                    Console.WriteLine("Timeline -- Rectangle=" + BitConverter.ToString(tl.Rectangle));
                }

            }

            void CheckTimelineActions(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiTimelineActionCount)
                {
                    FourJUserInterface.TimelineAction tl = new FourJUserInterface.TimelineAction();
                    tl.Unknown = Data.Skip(offset).Take(4).ToArray().Select(b => (byte)b).ToArray();
                    tl.UnknownName1 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x4).Take((int)0x40).ToArray());
                    tl.UnknownName2 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x44).Take((int)0x40).ToArray());
                    fui2.timelineActions.Add(tl);
                    offset += (int)0x84;
                    i++;


                    Console.Write("TimelineAction -- Unknown={");
                    foreach (byte item in tl.Unknown)
                    {
                        Console.Write(item + ", ");
                    }
                    Console.Write("}");
                    Console.WriteLine("");
                    Console.WriteLine("TimelineAction -- UnknownName1=" + tl.UnknownName1);
                    Console.WriteLine("TimelineAction -- UnknownName2=" + tl.UnknownName2);
                }
            }

            void CheckShapes(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiShapeCount)
                {
                    FourJUserInterface.Shape tl = new FourJUserInterface.Shape();
                    tl.UnknownValue1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                    tl.UnknownValue2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x4).Take(4).ToArray(), 0);
                    tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset + (int)0x8).Take(4).ToArray(), 0);
                    tl.Rectangle = (Data.Skip(offset + (int)0xc).Take((int)0x10).ToArray());
                    fui2.shapes.Add(tl);
                    offset += (int)0x1C;
                    i++;


                    Console.WriteLine("Shape -- UnknownValue1=" + tl.UnknownValue1);
                    Console.WriteLine("Shape -- UnknownValue2=" + tl.UnknownValue2);
                    Console.WriteLine("Shape -- ObjectType=" + tl.ObjectType);
                    Console.WriteLine("Shape -- Rectangle=" + BitConverter.ToString(tl.Rectangle));
                }
            }

            void CheckShapeComponents(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiShapeComponentCount)
                {
                    FourJUserInterface.ShapeComponent tl = new FourJUserInterface.ShapeComponent();
                    tl.FillInfo = (Data.Skip(offset).Take((int)0x1c).ToArray());
                    tl.UnknownValue1 = BitConverter.ToInt32(Data.Skip(offset + (int)0x24).Take(4).ToArray(), 0);
                    tl.UnknownValue2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x28).Take(4).ToArray(), 0);
                    fui2.shapeComponents.Add(tl);
                    offset += (int)0x2C;
                    i++;

                    Console.WriteLine("fuiShapeComponentCount -- FillInfo=" + tl.FillInfo);
                    Console.WriteLine("fuiShapeComponentCount -- UnknownValue1=" + tl.UnknownValue1);
                    Console.WriteLine("fuiShapeComponentCount -- UnknownValue2=" + tl.UnknownValue2);
                }
            }

            void CheckVerts(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiVertCount)
                {
                    FourJUserInterface.Vert tl = new FourJUserInterface.Vert();
                    tl.x = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                    tl.y = BitConverter.ToInt32(Data.Skip(offset + (int)0x4).Take(4).ToArray(), 0);
                    fui2.verts.Add(tl);
                    offset += (int)0x8;
                    i++;

                    Console.WriteLine("fuiVert -- x=" + tl.x);
                    Console.WriteLine("fuiVert -- y=" + tl.y);
                }
            }

            void CheckTimelineFrames(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiTimelineFrameCount)
                {
                    FourJUserInterface.TimelineFrame tl = new FourJUserInterface.TimelineFrame();
                    tl.FrameName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                    tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset + (int)0x40).Take(4).ToArray(), 0);
                    tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x44).Take(4).ToArray(), 0);
                    fui2.timelineFrames.Add(tl);
                    offset += (int)0x48;
                    i++;

                    Console.WriteLine("fuiTimelineFrame -- FrameName=" + tl.FrameName);
                    Console.WriteLine("fuiTimelineFrame -- Unknown1=" + tl.Unknown1);
                    Console.WriteLine("fuiTimelineFrame -- Unknown2=" + tl.Unknown2);
                }
            }

            void CheckTimelineEvents(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiTimelineEventCount)
                {
                    FourJUserInterface.TimelineEvent tl = new FourJUserInterface.TimelineEvent();
                    tl.Unknown = Data.Skip(offset).Take((int)0xc).ToArray().Select(b => (byte)b).ToArray();
                    tl.matrix = (Data.Skip(offset + (int)0xc).Take((int)0x18).ToArray());
                    tl.ColorTransform = (Data.Skip(offset + (int)0x24).Take((int)0x20).ToArray());
                    tl.Color = (Data.Skip(offset + (int)0x44).Take(4).ToArray());
                    fui2.timelineEvents.Add(tl);
                    offset += (int)0x48;
                    i++;

                    Console.Write("TimelineEvent -- Unknown={");
                    foreach (byte item in tl.Unknown)
                    {
                        Console.Write(item + ", ");
                    }
                    Console.Write("}");
                    Console.WriteLine("");
                    Console.WriteLine("TimelineEvent -- matrix=" + BitConverter.ToString(tl.matrix));
                    Console.WriteLine("TimelineEvent -- ColorTransform=" + BitConverter.ToString(tl.ColorTransform));
                    Console.WriteLine("TimelineEvent -- Color=" + BitConverter.ToString(tl.Color));
                }
            }

            void CheckTimelineEventNames(byte[] Data)
            {

                int i = 1;
                while (i <= fui2.header.fuiTimelineEventNameCount)
                {
                    FourJUserInterface.TimelineEventName tl = new FourJUserInterface.TimelineEventName();
                    tl.EventName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                    fui2.timelineEventNames.Add(tl);
                    offset += (int)0x40;
                    i++;

                    Console.WriteLine("TimelineEventName -- EventName=" + tl.EventName);
                }
            }

            void CheckReferences(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiReferenceCount)
                {
                    FourJUserInterface.Reference tl = new FourJUserInterface.Reference();
                    tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                    tl.ReferenceName = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x4).Take((int)0x40).ToArray());
                    tl.Unknown2 = (Data.Skip(offset + (int)0x40).Take(4).ToArray());
                    fui2.references.Add(tl);
                    offset += (int)0x48;
                    i++;

                    Console.WriteLine("Reference -- Unknown1=" + tl.Unknown1);
                    Console.WriteLine("Reference -- ReferenceName=" + tl.ReferenceName);
                    Console.WriteLine("Reference -- Unknown2=" + BitConverter.ToString(tl.Unknown2, 0));
                }
            }

            void CheckEdittexts(byte[] Data)
            {

                int i = 1;
                while (i <= fui2.header.fuiEdittextCount)
                {
                    FourJUserInterface.Edittext tl = new FourJUserInterface.Edittext();
                    tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                    tl.rectangle = Data.Skip(offset + (int)0x4).Take((int)0x10).ToArray();
                    tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x14).Take(4).ToArray(), 0);
                    tl.Unknown3 = BitConverter.ToInt32(Data.Skip(offset + (int)0x18).Take(4).ToArray(), 0);
                    tl.Color = (Data.Skip(offset + (int)0x1c).Take(4).ToArray());
                    tl.Unknown4 = Data.Skip(offset + (int)0x20).Take((int)0x18).ToArray();
                    tl.htmlTextFormat = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x38).Take((int)0x100).ToArray());
                    fui2.edittexts.Add(tl);
                    offset += (int)0x138;
                    i++;

                    Console.WriteLine("Edittext -- Unknown1=" + tl.Unknown1);
                    Console.WriteLine("Edittext -- rectangle=" + BitConverter.ToString(tl.rectangle));
                    Console.WriteLine("Edittext -- Unknown2=" + tl.Unknown2);
                    Console.WriteLine("Edittext -- Unknown3=" + tl.Unknown3);
                    Console.WriteLine("Edittext -- Color=" + BitConverter.ToString(tl.Color));
                    Console.Write("Edittext -- Unknown4={");
                    foreach (int item in tl.Unknown4)
                    {
                        Console.Write(item + ", ");
                    }
                    Console.Write("}");
                    Console.WriteLine("");
                    Console.WriteLine("Edittext -- htmlTextFormat=" + tl.htmlTextFormat);
                }
            }

            void CheckFontNames(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiFontNameCount)
                {
                    FourJUserInterface.FontName tl = new FourJUserInterface.FontName();
                    tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                    tl.Fontname = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x4).Take((int)0x40).ToArray());
                    tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x44).Take(4).ToArray(), 0);
                    tl.Unknown3 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x48).Take((int)0x40).ToArray());
                    tl.Unknown4 = Data.Skip(offset + (int)0x88).Take(8).ToArray();
                    tl.Unknown5 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x90).Take((int)0x40).ToArray());
                    tl.Unknown6 = Data.Skip(offset + (int)0xd0).Take(8).ToArray();
                    tl.Unknown7 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0xd8).Take((int)0x2c).ToArray());
                    fui2.fontNames.Add(tl);
                    offset += (int)0x104;
                    i++;

                    Console.WriteLine("FontName -- Unknown1=" + tl.Unknown1);
                    Console.WriteLine("FontName -- Fontname=" + tl.Fontname);
                    Console.WriteLine("FontName -- Unknown2=" + tl.Unknown2);
                    Console.WriteLine("FontName -- Unknown3=" + tl.Unknown3);
                    Console.Write("FontName -- Unknown4={");
                    foreach (int item in tl.Unknown4)
                    {
                        Console.Write(item + ", ");
                    }
                    Console.Write("}");
                    Console.WriteLine("");
                    Console.WriteLine("FontName -- Unknown5=" + tl.Unknown5);
                    Console.Write("FontName -- Unknown6={");
                    foreach (int item in tl.Unknown6)
                    {
                        Console.Write(item + ", ");
                    }
                    Console.Write("}");
                    Console.WriteLine("");
                    Console.WriteLine("FontName -- Unknown7=" + tl.Unknown7);
                }
            }

            void CheckSymbols(byte[] Data)
            {

                int i = 1;
                while (i <= fui2.header.fuiSymbolCount)
                {
                    FourJUserInterface.Symbol tl = new FourJUserInterface.Symbol();
                    tl.SymbolName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                    tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset + (int)0x40).Take(4).ToArray(), 0);
                    tl.Unknown = BitConverter.ToInt32(Data.Skip(offset + (int)0x44).Take(4).ToArray(), 0);
                    fui2.symbols.Add(tl);
                    offset += (int)0x48;
                    i++;

                    Console.WriteLine("Symbol -- SymbolName=" + tl.SymbolName);
                    Console.WriteLine("Symbol -- ObjectType=" + tl.ObjectType);
                    Console.WriteLine("Symbol -- Unknown=" + tl.Unknown);
                }
            }

            void CheckImportAssets(byte[] Data)
            {
                int i = 1;
                while (i <= fui2.header.fuiImportAssetCount)
                {
                    FourJUserInterface.ImportAsset tl = new FourJUserInterface.ImportAsset();
                    tl.AssetName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                    fui2.importAssets.Add(tl);
                    offset += (int)0x40;
                    i++;

                    Console.WriteLine("ImportAsset -- AssetName=" + tl.AssetName);
                }
            }

            void CheckBitmaps(byte[] Data)
            {
                int i = 1;
                Console.WriteLine("Offset: " + offset);
                while (i <= fui2.header.fuiBitmapCount)
                {
                    try
                    {
                        FourJUserInterface.Bitmap tl = new FourJUserInterface.Bitmap();
                        if (BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0) >= 1000000000)
                        {
                            List<byte> Dat1 = Data.Skip(offset).Take(4).ToList();
                            List<byte> Dat2 = Data.Skip(offset + (int)0x4).Take(4).ToList();;
                            List<byte> Dat3 = Data.Skip(offset + (int)0x8).Take(4).ToList();;
                            List<byte> Dat4 = Data.Skip(offset + (int)0xc).Take(4).ToList();;
                            List<byte> Dat5 = Data.Skip(offset + (int)0x10).Take(4).ToList();;
                            List<byte> Dat6 = Data.Skip(offset + (int)0x14).Take(4).ToList();;
                            List<byte> Dat7 = Data.Skip(offset + (int)0x18).Take(4).ToList();;
                            List<byte> Dat8 = Data.Skip(offset + (int)0x1c).Take(4).ToList();;

                            Dat1.Reverse();
                            Dat2.Reverse();
                            Dat3.Reverse();
                            Dat4.Reverse();
                            Dat5.Reverse();
                            Dat6.Reverse();
                            Dat7.Reverse();
                            Dat8.Reverse();

                            tl.Unknown1 = BitConverter.ToInt32(Dat1.ToArray(), 0);
                            tl.ObjectType = BitConverter.ToInt32(Dat2.ToArray(), 0);
                            tl.ScaleWidth = BitConverter.ToInt32(Dat3.ToArray(), 0);
                            tl.ScaleHeight = BitConverter.ToInt32(Dat4.ToArray(), 0);
                            tl.Size1 = BitConverter.ToInt32(Dat5.ToArray(), 0);
                            tl.Size2 = BitConverter.ToInt32(Dat6.ToArray(), 0);
                            tl.Unknown2 = BitConverter.ToInt32(Dat7.ToArray(), 0);
                            tl.Unknown3 = BitConverter.ToInt32(Dat8.ToArray(), 0);
                        }
                        else
                        {
                            tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                            tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset + (int)0x4).Take(4).ToArray(), 0);
                            tl.ScaleWidth = BitConverter.ToInt32(Data.Skip(offset + (int)0x8).Take(4).ToArray(), 0);
                            tl.ScaleHeight = BitConverter.ToInt32(Data.Skip(offset + (int)0xc).Take(4).ToArray(), 0);
                            tl.Size1 = BitConverter.ToInt32(Data.Skip(offset + (int)0x10).Take(4).ToArray(), 0);
                            tl.Size2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x14).Take(4).ToArray(), 0);
                            tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x18).Take(4).ToArray(), 0);
                            tl.Unknown3 = BitConverter.ToInt32(Data.Skip(offset + (int)0x1c).Take(4).ToArray(), 0);
                        }

                        fui2.bitmaps.Add(tl);
                        offset += 32;

                        //Get Images
                        //fui2.Images.Add(Data.Skip(offset).Take(tl.Size2).ToArray());
                        //offset += tl.Size2;

                        i++;

                        Console.WriteLine("Bitmap -- Unknown1=" + tl.Unknown1);
                        Console.WriteLine("Bitmap -- ObjectType=" + tl.ObjectType);
                        Console.WriteLine("Bitmap -- ScaleWidth=" + tl.ScaleWidth);
                        Console.WriteLine("Bitmap -- ScaleHeight=" + tl.ScaleHeight);
                        Console.WriteLine("Bitmap -- Size1=" + tl.Size1);
                        Console.WriteLine("Bitmap -- Size2=" + tl.Size2);
                        Console.WriteLine("Bitmap -- Unknown2=" + tl.Unknown2);
                    }
                    catch
                    {
                        MessageBox.Show(offset + "\n" + (offset-(int)0x20) + "");
                    }
                    foreach(FourJUserInterface.Bitmap bmp in fui2.bitmaps)
                    {
                        byte[] DataX = Data.Skip(offset).Take(bmp.Size2).ToArray();/*
                        MemoryStream ms = new MemoryStream(DataX, 0, DataX.Length);
                        System.Drawing.Image img = (System.Drawing.Bitmap.FromStream(ms));*/
                        fui2.Images.Add(DataX);

                        offset += bmp.Size2;
                    }
                }
            }

            public void SaveFUI(string path, FUI fjui)
            {
                Header header = fjui.header;

                List<byte> Output = new List<byte>();

                #region writing Header

                Output.AddRange(Encoding.ASCII.GetBytes(fjui.header.Identifier));
                Output.AddRange(BitConverter.GetBytes(fjui.header.Unknow));
                Output.AddRange(BitConverter.GetBytes(fjui.header.ContentSize));
                Output.AddRange(Encoding.ASCII.GetBytes(fjui.header.SwfFileName));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiTimelineCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiTimelineEventNameCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiTimelineActionCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiShapeCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiShapeComponentCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiVertCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiTimelineFrameCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiTimelineEventCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiReferenceCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiEdittextCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiSymbolCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiBitmapCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.imagesSize));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiFontNameCount));
                Output.AddRange(BitConverter.GetBytes(fjui.header.fuiImportAssetCount));
                Output.AddRange((fjui.header.FrameSize));
                #endregion
                if (header.fuiTimelineCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiTimelineCount)
                    {
                        Output.AddRange(BitConverter.GetBytes(fjui.timelines[i].ObjectType));
                            Output.AddRange(fjui.timelines[i].Unknown);
                        Output.AddRange(fjui.timelines[i].Rectangle);
                        i++;
                    }
                }
                if (header.fuiTimelineActionCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiTimelineActionCount)
                    {
                            Output.AddRange(fjui.timelineActions[i].Unknown);
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.timelineActions[i].UnknownName1));
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.timelineActions[i].UnknownName2));
                        i++;
                    }
                }
                if (header.fuiShapeCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiShapeCount)
                    {
                        Output.AddRange(BitConverter.GetBytes(fjui.shapes[i].UnknownValue1));
                        Output.AddRange(BitConverter.GetBytes(fjui.shapes[i].UnknownValue2));
                        Output.AddRange(BitConverter.GetBytes(fjui.shapes[i].ObjectType));
                        Output.AddRange((fjui.shapes[i].Rectangle));
                        i++;
                    }
                }
                if (header.fuiShapeComponentCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiShapeComponentCount)
                    {
                        Output.AddRange((fjui.shapeComponents[i].FillInfo));
                        Output.AddRange(BitConverter.GetBytes(fjui.shapeComponents[i].UnknownValue1));
                        Output.AddRange(BitConverter.GetBytes(fjui.shapeComponents[i].UnknownValue2));
                        i++;
                    }
                }
                if (header.fuiVertCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiVertCount)
                    {
                        Output.AddRange(BitConverter.GetBytes(fjui.verts[i].x));
                        Output.AddRange(BitConverter.GetBytes(fjui.verts[i].y));
                        i++;
                    }
                }
                if (header.fuiTimelineFrameCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiTimelineFrameCount)
                    {
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.timelineFrames[i].FrameName));
                        Output.AddRange(BitConverter.GetBytes(fjui.timelineFrames[i].Unknown1));
                        Output.AddRange(BitConverter.GetBytes(fjui.timelineFrames[i].Unknown2));
                        i++;
                    }
                }
                if (header.fuiTimelineEventCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiTimelineEventCount)
                    {
                        Output.AddRange(fjui.timelineEvents[i].Unknown);
                        Output.AddRange(fjui.timelineEvents[i].matrix);
                        Output.AddRange(fjui.timelineEvents[i].ColorTransform);
                        Output.AddRange(fjui.timelineEvents[i].Color);
                        i++;
                    }
                }
                if (header.fuiTimelineEventNameCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiTimelineEventNameCount)
                    {
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.timelineEventNames[i].EventName));
                        i++;
                    }
                }
                if (header.fuiReferenceCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiReferenceCount)
                    {
                        Output.AddRange(BitConverter.GetBytes(fjui.references[i].Unknown1));
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.references[i].ReferenceName));
                        Output.AddRange((fjui.references[i].Unknown2));
                        i++;
                    }
                }
                if (header.fuiEdittextCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiEdittextCount)
                    {
                        Output.AddRange(BitConverter.GetBytes(fjui.edittexts[i].Unknown1));
                        Output.AddRange((fjui.edittexts[i].rectangle));
                        Output.AddRange(BitConverter.GetBytes(fjui.edittexts[i].Unknown2));
                        Output.AddRange(BitConverter.GetBytes(fjui.edittexts[i].Unknown3));
                        Output.AddRange((fjui.edittexts[i].Color));
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.edittexts[i].htmlTextFormat));
                        i++;
                    }
                }
                if (header.fuiFontNameCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiFontNameCount)
                    {
                        Output.AddRange(BitConverter.GetBytes(fjui.fontNames[i].Unknown1));
                        Output.AddRange(BitConverter.GetBytes(fjui.fontNames[i].Unknown2));
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.fontNames[i].Unknown3));
                        Output.AddRange((fjui.fontNames[i].Unknown4));
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.fontNames[i].Unknown5));
                        Output.AddRange((fjui.fontNames[i].Unknown6));
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.fontNames[i].Unknown7));
                        i++;
                    }
                }
                if (header.fuiSymbolCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiSymbolCount)
                    {
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.symbols[i].SymbolName));
                        Output.AddRange(BitConverter.GetBytes(fjui.symbols[i].ObjectType));
                        Output.AddRange(BitConverter.GetBytes(fjui.symbols[i].Unknown));
                        i++;
                    }
                }
                if (header.fuiImportAssetCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiImportAssetCount)
                    {
                        Output.AddRange(Encoding.ASCII.GetBytes(fjui.importAssets[i].AssetName));
                        i++;
                    }
                }
                if (header.fuiBitmapCount > 0)
                {
                    int i = 0;
                    while (i < header.fuiBitmapCount)
                    {
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].Unknown1));
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].ObjectType));
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].ScaleWidth));
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].ScaleHeight));
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].Size1));
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].Size2));
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].Unknown2));
                        Output.AddRange(BitConverter.GetBytes(fjui.bitmaps[i].Unknown3));
                        i++;
                    }
                }
                foreach(byte[] dat in fjui.Images)
                {
                    Output.AddRange(dat);
                }
                /*
                */
                File.WriteAllBytes(path.Replace(".fui", "X1.fui"), Output.ToArray());
            }
        }

    }
}
