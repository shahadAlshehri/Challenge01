using System.Collections.Generic;
namespace csharp
{
    public class GildedRose
    {
        public static bool IsCorrectName(string Name)
        {
            return Name != "Aged Brie" 
            && Name != "Backstage passes to a TAFKAL80ETC concert"
            && Name != "Sulfuras, Hand of Ragnaros";
        }
        public static bool IsBiggerThanZero(int Number)
        {
            return Number > 0;
        }
        public static bool IsLessThanFifty(int Number)
        {
            return Number < 50;
        }
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsCorrectName(item.Name) && IsBiggerThanZero(item.Quality))
                {
                    item.Quality -= 1;
                }
                else
                {
                    if (IsLessThanFifty(item.Quality))
                    {
                        item.Quality = item.Quality + 1;
                        if (IsLessThanFifty(item.Quality) && item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                                item.Quality +=  1;
                        }
                    }
                }
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                    item.SellIn -=1;
                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (IsCorrectName(item.Name) && IsBiggerThanZero(item.Quality))
                            item.Quality -=  1;
                        else
                            item.Quality -=  item.Quality;
                    }
                    else
                    {
                        if (IsLessThanFifty(item.Quality))
                            item.Quality +=  1;
                    }
                }
            }
        }
    }
}
