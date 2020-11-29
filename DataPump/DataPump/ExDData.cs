using System;

namespace DataPump
{
    interface ExDData
    {
        Type GetType();

        object GetData();
    }

    /*class ExDByte : ExDData<byte>
    {
        public byte GetData()
        {

        }
    }*/
}
