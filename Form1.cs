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
            Console.WriteLine("FrameSize - " + Encoding.Default.GetString(FrameSize));

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
            }
        }

        void CheckVerts(byte[] Data)
        {

        }

        void CheckTimelineFrames(byte[] Data)
        {

        }

        void CheckTimelineEvents(byte[] Data)
        {

        }

        void CheckTimelineEventNames(byte[] Data)
        {

        }

        void CheckReferences(byte[] Data)
        {

        }

        void CheckEdittexts(byte[] Data)
        {

        }

        void CheckFontNames(byte[] Data)
        {

        }

        void CheckSymbols(byte[] Data)
        {

        }

        void CheckImportAssets(byte[] Data)
        {

        }

        void CheckBitmaps(byte[] Data)
        {

        }

        #endregion

    }
}
