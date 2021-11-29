using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FUI_Doc_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public FourJUserInterface.FUI FUI = new FourJUserInterface.FUI();

        private void LoadButton_Click(object sender, EventArgs e)
        {
            Console.Clear();
            OpenFUI(textBox1.Text);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "FUI Files|*.fui";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = opf.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream filestream = new FileStream("out.txt", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.CurrentDirectory + "\\Controls720.fui";
        }

        #region FUI Reading

        void OpenFUI(string Path)
        {
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


            FUI.header.Identifier = Encoding.Default.GetString(Identifier);
            FUI.header.Unknow = BitConverter.ToInt32(Unknow, 0);
            FUI.header.ContentSize = BitConverter.ToInt32(ContentSize, 0);
            FUI.header.SwfFileName = Encoding.Default.GetString(SwfFileName);
            FUI.header.fuiTimelineCount = BitConverter.ToInt32(fuiTimelineCount, 0);
            FUI.header.fuiTimelineEventNameCount = BitConverter.ToInt32(fuiTimelineEventNameCount, 0);
            FUI.header.fuiTimelineActionCount = BitConverter.ToInt32(fuiTimelineActionCount, 0);
            FUI.header.fuiShapeCount = BitConverter.ToInt32(fuiShapeCount, 0);
            FUI.header.fuiShapeComponentCount = BitConverter.ToInt32(fuiShapeComponentCount, 0);
            FUI.header.fuiVertCount = BitConverter.ToInt32(fuiVertCount, 0);
            FUI.header.fuiTimelineFrameCount = BitConverter.ToInt32(fuiTimelineFrameCount, 0);
            FUI.header.fuiTimelineEventCount = BitConverter.ToInt32(fuiTimelineEventCount, 0);
            FUI.header.fuiReferenceCount = BitConverter.ToInt32(fuiReferenceCount, 0);
            FUI.header.fuiEdittextCount = BitConverter.ToInt32(fuiEdittextCount, 0);
            FUI.header.fuiSymbolCount = BitConverter.ToInt32(fuiSymbolCount, 0);
            FUI.header.fuiBitmapCount = BitConverter.ToInt32(fuiBitmapCount, 0);
            FUI.header.imagesSize = BitConverter.ToInt32(imagesSize, 0);
            FUI.header.fuiFontNameCount = BitConverter.ToInt32(fuiFontNameCount, 0);
            FUI.header.fuiImportAssetCount = BitConverter.ToInt32(fuiImportAssetCount, 0);
            FUI.header.FrameSize = (FrameSize);


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
            Output.AddRange(Encoding.UTF8.GetBytes(FUI.header.Identifier));
            Output.AddRange(BitConverter.GetBytes(FUI.header.Unknow));
            Output.AddRange(BitConverter.GetBytes(FUI.header.ContentSize));
            Output.AddRange(Encoding.UTF8.GetBytes(FUI.header.SwfFileName));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiTimelineCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiTimelineEventNameCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiTimelineActionCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiShapeCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiShapeComponentCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiVertCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiTimelineFrameCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiTimelineEventCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiReferenceCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiEdittextCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiSymbolCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiBitmapCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.imagesSize));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiFontNameCount));
            Output.AddRange(BitConverter.GetBytes(FUI.header.fuiImportAssetCount));
            Output.AddRange((FUI.header.FrameSize));

            if (BitConverter.ToString(Output.ToArray()) != BitConverter.ToString(Header))
                throw new Exception();

        }

        int offset = (int)0x98;

        void CheckTimelines(byte[] Data)
        {
            int i = 1;
            while (i <= FUI.header.fuiTimelineCount) 
            {
                FourJUserInterface.Timeline tl = new FourJUserInterface.Timeline();
                tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                tl.Unknown = Data.Skip(offset+4).Take(8).ToArray().Select(b => (short)b).ToArray();
                tl.Rectangle = Data.Skip(offset+(int)0xc).Take((int)0x10).ToArray();
                FUI.timelines.Add(tl);
                offset += (int)0x1C;
                i++;


                Console.WriteLine("Timeline -- ObjectType=" + tl.ObjectType);
                Console.WriteLine("Timeline -- Unknown=" + tl.Unknown);
                Console.WriteLine("Timeline -- Rectangle=" + BitConverter.ToString(tl.Rectangle));
            }

        }

        void CheckTimelineActions(byte[] Data)
        {
            int i = 1;
            while (i <= FUI.header.fuiTimelineActionCount)
            {
                FourJUserInterface.TimelineAction tl = new FourJUserInterface.TimelineAction();
                tl.Unknown = Data.Skip(offset).Take(4).ToArray().Select(b => (short)b).ToArray();
                tl.UnknownName1 = Encoding.UTF8.GetString(Data.Skip(offset+(int)0x4).Take((int)0x40).ToArray());
                tl.UnknownName2 = Encoding.UTF8.GetString(Data.Skip(offset+(int)0x44).Take((int)0x40).ToArray());
                FUI.timelineActions.Add(tl);
                offset += (int)0x84;
                i++;


                Console.Write("TimelineAction -- Unknown={");
                foreach(short item in tl.Unknown)
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
            while (i <= FUI.header.fuiShapeCount)
            {
                FourJUserInterface.Shape tl = new FourJUserInterface.Shape();
                tl.UnknownValue1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                tl.UnknownValue2 = BitConverter.ToInt32(Data.Skip(offset+(int)0x4).Take(4).ToArray(), 0);
                tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset+(int)0x8).Take(4).ToArray(), 0);
                tl.Rectangle = (Data.Skip(offset+(int)0xc).Take((int)0x10).ToArray());
                FUI.shapes.Add(tl);
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
            while (i <= FUI.header.fuiShapeComponentCount)
            {
                FourJUserInterface.ShapeComponent tl = new FourJUserInterface.ShapeComponent();
                tl.FillInfo = (Data.Skip(offset).Take((int)0x1c).ToArray());
                tl.UnknownValue1 = BitConverter.ToInt32(Data.Skip(offset + (int)0x24).Take(4).ToArray(), 0);
                tl.UnknownValue2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x28).Take(4).ToArray(), 0);
                FUI.shapeComponents.Add(tl);
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
            while (i <= FUI.header.fuiVertCount)
            {
                FourJUserInterface.Vert tl = new FourJUserInterface.Vert();
                tl.x = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                tl.y = BitConverter.ToInt32(Data.Skip(offset + (int)0x4).Take(4).ToArray(), 0);
                FUI.verts.Add(tl);
                offset += (int)0x8;
                i++;

                Console.WriteLine("fuiVert -- x=" + tl.x);
                Console.WriteLine("fuiVert -- y=" + tl.y);
            }
        }

        void CheckTimelineFrames(byte[] Data)
        {
            int i = 1;
            while (i <= FUI.header.fuiTimelineFrameCount)
            {
                FourJUserInterface.TimelineFrame tl = new FourJUserInterface.TimelineFrame();
                tl.FrameName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset+(int)0x40).Take(4).ToArray(), 0);
                tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset+(int)0x44).Take(4).ToArray(), 0);
                FUI.timelineFrames.Add(tl);
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
            while (i <= FUI.header.fuiTimelineEventCount)
            {
                FourJUserInterface.TimelineEvent tl = new FourJUserInterface.TimelineEvent();
                tl.Unknown = Data.Skip(offset).Take((int)0xc).ToArray().Select(b => (short)b).ToArray();
                tl.matrix = (Data.Skip(offset + (int)0xc).Take((int)0x18).ToArray());
                tl.ColorTransform = (Data.Skip(offset + (int)0x24).Take((int)0x20).ToArray());
                tl.Color = (Data.Skip(offset + (int)0x44).Take(4).ToArray());
                FUI.timelineEvents.Add(tl);
                offset += (int)0x48;
                i++;

                Console.Write("TimelineEvent -- Unknown={");
                foreach (short item in tl.Unknown)
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
            while (i <= FUI.header.fuiTimelineEventNameCount)
            {
                FourJUserInterface.TimelineEventName tl = new FourJUserInterface.TimelineEventName();
                tl.EventName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                FUI.timelineEventNames.Add(tl);
                offset += (int)0x40;
                i++;

                Console.WriteLine("TimelineEventName -- EventName=" + tl.EventName);
            }
        }

        void CheckReferences(byte[] Data)
        {
            int i = 1;
            while (i <= FUI.header.fuiReferenceCount)
            {
                FourJUserInterface.Reference tl = new FourJUserInterface.Reference();
                tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                tl.ReferenceName = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x4).Take((int)0x40).ToArray());
                tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x8).Take(4).ToArray(), 0);
                FUI.references.Add(tl);
                offset += (int)0x48;
                i++;

                Console.WriteLine("Reference -- Unknown1=" + tl.Unknown1);
                Console.WriteLine("Reference -- ReferenceName=" + tl.ReferenceName);
                Console.WriteLine("Reference -- Unknown2=" + tl.Unknown2);
            }
        }

        void CheckEdittexts(byte[] Data)
        {

            int i = 1;
            while (i <= FUI.header.fuiEdittextCount)
            {
                FourJUserInterface.Edittext tl = new FourJUserInterface.Edittext();
                tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                tl.rectangle = Data.Skip(offset+(int)0x4).Take((int)0x10).ToArray();
                tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset+(int)0x14).Take(4).ToArray(), 0);
                tl.Unknown3 = BitConverter.ToInt32(Data.Skip(offset+(int)0x18).Take(4).ToArray(), 0);
                tl.Color = (Data.Skip(offset+(int)0x1c).Take(4).ToArray());
                tl.Unknown4 = Data.Skip(offset+(int)0x20).Take((int)0x18).ToArray().Select(b => (int)b).ToArray();
                tl.htmlTextFormat = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x38).Take((int)0x100).ToArray());
                FUI.edittexts.Add(tl);
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
            while (i <= FUI.header.fuiFontNameCount)
            {
                FourJUserInterface.FontName tl = new FourJUserInterface.FontName();
                tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                tl.Fontname = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x4).Take((int)0x40).ToArray());
                tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x44).Take(4).ToArray(), 0);
                tl.Unknown3 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x48).Take((int)0x40).ToArray());
                tl.Unknown4 = Data.Skip(offset + (int)0x88).Take(8).ToArray().Select(b => (int)b).ToArray();
                tl.Unknown5 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0x90).Take((int)0x40).ToArray());
                tl.Unknown6 = Data.Skip(offset + (int)0xd0).Take(8).ToArray().Select(b => (int)b).ToArray();
                tl.Unknown7 = Encoding.UTF8.GetString(Data.Skip(offset + (int)0xd8).Take((int)0x2c).ToArray());
                FUI.fontNames.Add(tl);
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
            while (i <= FUI.header.fuiSymbolCount)
            {
                FourJUserInterface.Symbol tl = new FourJUserInterface.Symbol();
                tl.SymbolName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset+ (int)0x40).Take(4).ToArray(), 0);
                tl.Unknown = BitConverter.ToInt32(Data.Skip(offset+ (int)0x44).Take(4).ToArray(), 0);
                FUI.symbols.Add(tl);
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
            while (i <= FUI.header.fuiImportAssetCount)
            {
                FourJUserInterface.ImportAsset tl = new FourJUserInterface.ImportAsset();
                tl.AssetName = Encoding.UTF8.GetString(Data.Skip(offset).Take((int)0x40).ToArray());
                FUI.importAssets.Add(tl);
                offset += (int)0x40;
                i++;

                Console.WriteLine("ImportAsset -- AssetName=" + tl.AssetName);
            }
        }

        void CheckBitmaps(byte[] Data)
        {
            int i = 1;
            while (i <= FUI.header.fuiBitmapCount)
            {
                FourJUserInterface.Bitmap tl = new FourJUserInterface.Bitmap();
                tl.Unknown1 = BitConverter.ToInt32(Data.Skip(offset).Take(4).ToArray(), 0);
                tl.ObjectType = BitConverter.ToInt32(Data.Skip(offset + (int)0x4).Take(4).ToArray(), 0);
                tl.ScaleWidth = BitConverter.ToInt32(Data.Skip(offset + (int)0x8).Take(4).ToArray(), 0);
                tl.ScaleHeight = BitConverter.ToInt32(Data.Skip(offset + (int)0xc).Take(4).ToArray(), 0);
                tl.Size1 = BitConverter.ToInt32(Data.Skip(offset + (int)0x10).Take(4).ToArray(), 0);
                tl.Size2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x14).Take(4).ToArray(), 0);
                tl.Unknown2 = BitConverter.ToInt32(Data.Skip(offset + (int)0x18).Take(4).ToArray(), 0);

                FUI.bitmaps.Add(tl);
                offset += (int)0x20;

                //Get Images
                FUI.Images.Add(Data.Skip(offset).Take(tl.Size2).ToArray());
                offset += tl.Size2;

                i++;

                Console.WriteLine("Bitmap -- Unknown1=" + tl.Unknown1);
                Console.WriteLine("Bitmap -- ObjectType=" + tl.ObjectType);
                Console.WriteLine("Bitmap -- ScaleWidth=" + tl.ScaleWidth);
                Console.WriteLine("Bitmap -- ScaleHeight=" + tl.ScaleHeight);
                Console.WriteLine("Bitmap -- Size1=" + tl.Size1);
                Console.WriteLine("Bitmap -- Size2=" + tl.Size2);
                Console.WriteLine("Bitmap -- Unknown2=" + tl.Unknown2);
            }
            Console.WriteLine("Offset: " + offset);
        }

        #endregion

    }
}
