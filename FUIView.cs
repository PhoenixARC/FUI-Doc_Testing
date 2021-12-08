using System;
using System.Windows.Forms;

namespace FUI_Doc_Testing
{
    public partial class FUIView : Form
    {
        public FUIView(FourJUserInterface.FUI FUIObject)
        {
            InitializeComponent();
            FUI = FUIObject;
        }

        FourJUserInterface.FUI FUI;

        private void FUIView_Load(object sender, EventArgs e)
        {
            TreeNode MASTER = new TreeNode(FUI.header.SwfFileName);
            textBox1.Text = FUI.header.Identifier;
            textBox2.Text = FUI.header.Unknow.ToString();
            textBox3.Text = FUI.header.ContentSize.ToString();
            textBox4.Text = FUI.header.SwfFileName.ToString();
            textBox5.Text = FUI.header.fuiTimelineCount.ToString();
            textBox6.Text = FUI.header.fuiTimelineEventNameCount.ToString();
            textBox7.Text = FUI.header.fuiTimelineActionCount.ToString();
            textBox8.Text = FUI.header.fuiShapeCount.ToString();
            textBox9.Text = FUI.header.fuiShapeComponentCount.ToString();
            textBox10.Text = FUI.header.fuiVertCount.ToString();
            textBox11.Text = FUI.header.fuiTimelineFrameCount.ToString();
            textBox12.Text = FUI.header.fuiTimelineEventCount.ToString();
            textBox13.Text = FUI.header.fuiReferenceCount.ToString();
            textBox14.Text = FUI.header.fuiEdittextCount.ToString();
            textBox15.Text = FUI.header.fuiSymbolCount.ToString();
            textBox16.Text = FUI.header.fuiBitmapCount.ToString();
            textBox17.Text = FUI.header.imagesSize.ToString();
            textBox18.Text = FUI.header.fuiFontNameCount.ToString();
            textBox19.Text = FUI.header.fuiImportAssetCount.ToString();
            textBox20.Text = BitConverter.ToString(FUI.header.FrameSize);



            TreeNode timelines = new TreeNode("timelines");
            TreeNode timelineActions = new TreeNode("timeline Actions");
            TreeNode shapes = new TreeNode("shapes");
            TreeNode shapeComponents = new TreeNode("shape Components");
            TreeNode verts = new TreeNode("verts");
            TreeNode timelineFrames = new TreeNode("timeline Frames");
            TreeNode timelineEvents = new TreeNode("timeline Events");
            TreeNode timelineEventNames = new TreeNode("timeline Event Names");
            TreeNode references = new TreeNode("references");
            TreeNode edittexts = new TreeNode("edit texts");
            TreeNode fontNames = new TreeNode("font Names");
            TreeNode symbols = new TreeNode("symbols");
            TreeNode importAssets = new TreeNode("import Assets");
            TreeNode bitmaps = new TreeNode("bitmaps");

            if (FUI.header.fuiTimelineCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiTimelineCount)
                {
                    TreeNode tl = new TreeNode("Timeline"+i);
                    tl.Tag = FUI.timelines[i].ObjectType + "\n{";
                    foreach (sbyte shr in FUI.timelines[i].Unknown) { tl.Tag += shr+ ", "; }
                    tl.Tag += "}\n" + BitConverter.ToString(FUI.timelines[i].Rectangle);
                    timelines.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(timelines);
            }
            if (FUI.header.fuiTimelineActionCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiTimelineActionCount)
                {
                    TreeNode tl = new TreeNode("TimelineAction" + i);
                    tl.Tag = "";
                    foreach (short shr in FUI.timelineActions[i].Unknown) { tl.Tag += shr + ", "; }
                    tl.Tag += "\n"+FUI.timelineActions[i].UnknownName1;
                    tl.Tag += "\n"+FUI.timelineActions[i].UnknownName2;
                    timelineActions.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(timelineActions);
            }
            if (FUI.header.fuiShapeCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiShapeCount)
                {
                    TreeNode tl = new TreeNode("Shape" + i);
                    tl.Tag = FUI.shapes[i].UnknownValue1 + "\n";
                    tl.Tag += FUI.shapes[i].UnknownValue2 + "\n";
                    tl.Tag += FUI.shapes[i].ObjectType + "\n";
                    tl.Tag += BitConverter.ToString(FUI.shapes[i].Rectangle);
                    shapes.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(shapes);
            }
            if (FUI.header.fuiShapeComponentCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiShapeComponentCount)
                {
                    TreeNode tl = new TreeNode("ShapeComponent" + i);
                    tl.Tag = BitConverter.ToString(FUI.shapeComponents[i].FillInfo);
                    tl.Tag += FUI.shapeComponents[i].UnknownValue1 + "\n";
                    tl.Tag += FUI.shapeComponents[i].UnknownValue2 + "\n";
                    shapeComponents.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(shapeComponents);
            }
            if (FUI.header.fuiVertCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiTimelineCount)
                {
                    TreeNode tl = new TreeNode("Vert" + i);
                    tl.Tag = FUI.verts[i].x + "\n";
                    tl.Tag = FUI.verts[i].y + "\n";
                    verts.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(verts);
            }
            if (FUI.header.fuiTimelineFrameCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiTimelineFrameCount)
                {
                    TreeNode tl = new TreeNode("TimelineFrame" + i);
                    tl.Tag = FUI.timelineFrames[i].FrameName + "\n";
                    tl.Tag += FUI.timelineFrames[i].Unknown1 + "\n";
                    tl.Tag += FUI.timelineFrames[i].Unknown2 + "";
                    timelineFrames.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(timelineFrames);
            }
            if (FUI.header.fuiTimelineEventCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiTimelineEventCount)
                {
                    TreeNode tl = new TreeNode("TimelineEvent" + i);
                    tl.Tag = "{";
                    foreach (short shr in FUI.timelineEvents[i].Unknown) { tl.Tag += shr + ", "; }
                    tl.Tag += "}\n" + BitConverter.ToString(FUI.timelineEvents[i].matrix);
                    tl.Tag += "\n" + BitConverter.ToString(FUI.timelineEvents[i].ColorTransform);
                    tl.Tag += "\n" + BitConverter.ToString(FUI.timelineEvents[i].Color);
                    timelineEvents.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(timelineEvents);
            }
            if (FUI.header.fuiTimelineEventNameCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiTimelineEventNameCount)
                {
                    TreeNode tl = new TreeNode("TimelineEventName" + i);
                    tl.Tag = FUI.timelineEventNames[i].EventName + "";
                    timelineEventNames.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(timelineEventNames);
            }
            if (FUI.header.fuiReferenceCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiReferenceCount)
                {
                    TreeNode tl = new TreeNode("Reference" + i);
                    tl.Tag = FUI.references[i].Unknown1 + "\n";
                    tl.Tag = FUI.references[i].ReferenceName + "\n";
                    tl.Tag = FUI.references[i].Unknown2 + "";
                    references.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(references);
            }
            if (FUI.header.fuiEdittextCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiEdittextCount)
                {
                    TreeNode tl = new TreeNode("EditText" + i);
                    tl.Tag = FUI.edittexts[i].Unknown1 + "\n";
                    tl.Tag += BitConverter.ToString(FUI.edittexts[i].rectangle);
                    tl.Tag += FUI.edittexts[i].Unknown2 + "\n";
                    tl.Tag += FUI.edittexts[i].Unknown3 + "\n";
                    tl.Tag += BitConverter.ToString(FUI.edittexts[i].Color) + "\n{";
                    foreach (int shr in FUI.edittexts[i].Unknown4) { tl.Tag += shr + ", "; }
                    tl.Tag += "}\n" + FUI.edittexts[i].htmlTextFormat + "";
                    edittexts.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(edittexts);
            }
            if (FUI.header.fuiFontNameCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiFontNameCount)
                {
                    TreeNode tl = new TreeNode("FontName" + i);
                    tl.Tag = FUI.fontNames[i].Unknown1 + "\n";
                    tl.Tag += FUI.fontNames[i].Fontname + "\n";
                    tl.Tag += FUI.fontNames[i].Unknown2 + "\n";
                    tl.Tag += FUI.fontNames[i].Unknown3 + "\n{";
                    foreach (short shr in FUI.fontNames[i].Unknown4) { tl.Tag += shr + ", "; }
                    tl.Tag += "}\n" + FUI.fontNames[i].Unknown5 + "\n{";
                    foreach (short shr in FUI.fontNames[i].Unknown6) { tl.Tag += shr + ", "; }
                    tl.Tag += "}\n" + FUI.fontNames[i].Unknown7 + "";
                    fontNames.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(fontNames);
            }
            if (FUI.header.fuiSymbolCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiSymbolCount)
                {
                    TreeNode tl = new TreeNode("Symbol" + i);
                    tl.Tag = FUI.symbols[i].SymbolName + "\n";
                    tl.Tag += FUI.symbols[i].ObjectType + "\n";
                    tl.Tag += FUI.symbols[i].Unknown + "\n";
                    symbols.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(symbols);
            }
            if (FUI.header.fuiImportAssetCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiImportAssetCount)
                {
                    TreeNode tl = new TreeNode("ImportAsset" + i);
                    tl.Tag = FUI.importAssets[i].AssetName + "";
                    importAssets.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(importAssets);
            }
            if (FUI.header.fuiBitmapCount > 0)
            {
                int i = 0;
                while (i < FUI.header.fuiBitmapCount)
                {
                    TreeNode tl = new TreeNode("Bitmap" + i);
                    tl.Tag = FUI.bitmaps[i].Unknown1 + "\n";
                    tl.Tag += FUI.bitmaps[i].ObjectType + "\n";
                    tl.Tag += FUI.bitmaps[i].ScaleWidth + "\n";
                    tl.Tag += FUI.bitmaps[i].ScaleHeight + "\n";
                    tl.Tag += FUI.bitmaps[i].Size1 + "\n";
                    tl.Tag += FUI.bitmaps[i].Size2 + "\n";
                    tl.Tag += FUI.bitmaps[i].Unknown2 + "";
                    bitmaps.Nodes.Add(tl);
                    i++;
                }
                MASTER.Nodes.Add(bitmaps);
            }

            treeView1.Nodes.Add(MASTER);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
            {
                try
                {
                    richTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
                }
                catch { }
            }
        }
    }
}
