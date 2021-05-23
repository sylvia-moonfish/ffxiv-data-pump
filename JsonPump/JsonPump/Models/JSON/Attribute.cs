using System;

namespace JsonPump.Models.JSON
{
    public class Attribute
    {
        public Attribute()
        {
            wd = 0;
            str = 0;
            dex = 0;
            @int = 0;
            mnd = 0;
            ch = 0;
            dh = 0;
            det = 0;
            sks = 0;
            sps = 0;
            ten = 0;
            pie = 0;
        }

        public int wd { get; set; }
        public int str { get; set; }
        public int dex { get; set; }
        public int @int { get; set; }
        public int mnd { get; set; }
        public int ch { get; set; }
        public int dh { get; set; }
        public int det { get; set; }
        public int sks { get; set; }
        public int sps { get; set; }
        public int ten { get; set; }
        public int pie { get; set; }

        public void Add(Attribute attribute)
        {
            wd += attribute.wd;
            str += attribute.str;
            dex += attribute.dex;
            @int += attribute.@int;
            mnd += attribute.mnd;
            ch += attribute.ch;
            dh += attribute.dh;
            det += attribute.det;
            sks += attribute.sks;
            sps += attribute.sps;
            ten += attribute.ten;
            pie += attribute.pie;
        }

        public void Add(Attribute attribute, int max)
        {
            wd += attribute.wd;
            str += attribute.str;
            dex += attribute.dex;
            @int += attribute.@int;
            mnd += attribute.mnd;
            ch = Math.Min(ch + attribute.ch, max);
            dh = Math.Min(dh + attribute.dh, max);
            det = Math.Min(det + attribute.det, max);
            sks = Math.Min(sks + attribute.sks, max);
            sps = Math.Min(sps + attribute.sps, max);
            ten = Math.Min(ten + attribute.ten, max);
            pie = Math.Min(pie + attribute.pie, max);
        }

        public void ApplyFood(MealAttribute mealAttribute)
        {
            if (mealAttribute.ch != null)
                ch += Math.Min((int) Math.Floor((double) ch * mealAttribute.ch.value / 100.0d), mealAttribute.ch.max);

            if (mealAttribute.dh != null)
                dh += Math.Min((int) Math.Floor((double) dh * mealAttribute.dh.value / 100.0d), mealAttribute.dh.max);

            if (mealAttribute.det != null)
                det += Math.Min((int) Math.Floor((double) det * mealAttribute.det.value / 100.0d),
                    mealAttribute.det.max);

            if (mealAttribute.sks != null)
                sks += Math.Min((int) Math.Floor((double) sks * mealAttribute.sks.value / 100.0d),
                    mealAttribute.sks.max);

            if (mealAttribute.sps != null)
                sps += Math.Min((int) Math.Floor((double) sps * mealAttribute.sps.value / 100.0d),
                    mealAttribute.sps.max);

            if (mealAttribute.ten != null)
                ten += Math.Min((int) Math.Floor((double) ten * mealAttribute.ten.value / 100.0d),
                    mealAttribute.ten.max);
            if (mealAttribute.pie != null)
                pie += Math.Min((int) Math.Floor((double) pie * mealAttribute.pie.value / 100.0d),
                    mealAttribute.pie.max);
        }
    }
}