using System;


[Serializable]
public class SizeItem
{
   // public int ID { get; set; }
 //   public int Sizeid { get; set; }

    public int SizeId { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    

    public SizeItem(){}


    public SizeItem( int psizeId, int psize,int pcount)
    {
        Count = pcount;
        SizeId = psizeId;
        Size = psize;
    }
}