using System;
using System.Collections.Generic;
using System.Text;

namespace MDSolution
{
    class NodeHangHoa
    {

        private string mID = "-1";
        private string mName = "";
        private HangHoaType mType = HangHoaType.Root;
        public NodeHangHoa()
        {
        }
        public NodeHangHoa(string ID, string Name,HangHoaType Type)
        {
            mID = ID;
            mName = Name;
            mType = Type;
        }
        public string ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public HangHoaType Type
        {
            get { return mType; }
            set { this.mType = value; }
        }
    }
    [Flags]
    public enum HangHoaType : int
    {
        Root = 0,
        Hang = 1,

    }
}