using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
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
            public short[] Unknown;
            public byte[] Rectangle;
        }

        //fuiTimelineAction	0x84
        public class TimelineAction
        {
            public short[] Unknown;
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
            public short Unknown;
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
            public string AssetName;
        }

        //fuiEdittext	0x138
        public class Edittext
        {
            public int Unknown1;
            public byte[] rectangle;
            public int Unknown2;
            public float Unknown3;
            public byte[] Color;
            public int Unknown4;
            public string htmlTextFormat;
        }

        //fuiFontName	0x104
        public class FontName
        {
            public int Unknown1;
            public string Fontname;
            public int Unknown2;
            public string Unknown3;
            public int Unknown4;
            public string Unknown5;
            public int Unknown6;
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
        }


    }
}
