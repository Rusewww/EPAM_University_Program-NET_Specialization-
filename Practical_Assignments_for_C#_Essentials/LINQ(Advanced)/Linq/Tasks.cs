using System;
using System.Linq;
using Linq.Objects;
using System.Collections.Generic;

namespace Linq
{
    public static class Tasks
    {
        public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
        {
            return stringList.Where(s => s.Length > 1 && s.StartsWith(c) && s.EndsWith(c));
        }

        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(s => s.Length).OrderBy(n => n);
        }

        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(s => s[0].ToString() + s[^1]);
        }

        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            return stringList.Where(s => s.Length == k && char.IsDigit(s.Last())).OrderBy(s => s);
        }

        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(n => n % 2 == 1).OrderBy(n => n).Select(n => n.ToString());
        }

        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            return numbers.Select(n => stringList.FirstOrDefault(s => s.Length == n && char.IsDigit(s[0]))).Select(s => s ?? "Not found");
        }

        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        {
            return integerList.Where(i => i % 2 == 0).Except(integerList.Skip(k)).Reverse();
        }

        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            var subset1 = integerList.TakeWhile(n => n <= d).ToList();
            var subset2 = integerList.Skip(k).ToList();
            var union = subset1.Union(subset2);
            return union.OrderByDescending(n => n);
        }

        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            var groups = stringList.GroupBy(x => x[0]);
            var sums = groups.Select(g => new { Char = g.Key, Sum = g.Sum(s => s.Length) });
            var ordered = sums.OrderByDescending(x => x.Sum).ThenBy(x => x.Char);
            var result = ordered.Select(x => $"{x.Sum}-{x.Char}");
            return result;
        }

        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            return stringList.OrderBy(i => i).GroupBy(i => i.Count()).Select(i => i.Aggregate("", (a, b) => (a + b[^1]).ToUpper())).OrderByDescending(i => i.Count());
        }

        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            return nameList.GroupBy(y => y.Year).Select(n => new YearSchoolStat { Year = n.Key, NumberOfSchools = n.Select(s => s.SchoolNumber).Distinct().Count() }).OrderBy(n => n.NumberOfSchools).ThenBy(y => y.Year);
        }

        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            return integerList1.SelectMany(i1 => integerList2, (i1, i2) => new NumberPair { Item1 = i1, Item2 = i2 }).Where(pair => pair.Item1 % 10 == pair.Item2 % 10).OrderBy(pair => pair.Item1).ThenBy(pair => pair.Item2);
        }


        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            
            return yearList.Select(n => new YearSchoolStat { Year = n, NumberOfSchools = nameList.Where(y => y.Year == n).Select(s => s.SchoolNumber).Distinct().Count() }).OrderBy(n => n.NumberOfSchools).ThenBy(y => y.Year);
        }

        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList, IEnumerable<SupplierDiscount> supplierDiscountList)
        {
            return supplierDiscountList.GroupBy(sd => sd.ShopName).Select(g => new MaxDiscountOwner
                {
                    ShopName = g.Key,
                    Owner = supplierList
                        .Where(s => g.Select(sd => sd.SupplierId).Contains(s.Id))
                        .OrderBy(s => s.Id)
                        .FirstOrDefault(s => g.Where(sd => sd.SupplierId == s.Id)
                            .Max(sd => sd.Discount) == g.Max(sd => sd.Discount)),
                    Discount = g.Max(sd => sd.Discount)
                })
                .OrderBy(mdo => mdo.ShopName);
        }

        public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
            IEnumerable<StorePrice> storePriceList)
        {
            return goodList.Where(x => !storePriceList.Select(n => n.GoodId).Contains(x.Id)).Select(x => new CountryStat
            {
                Country = x.Country,
                MinPrice = 0.0m,
                StoresNumber = 0
            }).Distinct().Union(storePriceList.Join(goodList, sPL => sPL.GoodId, gL => gL.Id, (sPL, gL) => new
            {
                country = gL.Country,
                price = sPL.Price,
                stores = sPL.Shop
            }).GroupBy(x => x.country, x => (x.price, x.stores), (con, dat) => new CountryStat
            {
                Country = con,
                MinPrice = dat.Select(x => x.price).Min(),
                StoresNumber = dat.Select(x => x.stores).Distinct().Count()
            })).OrderBy(x => x.Country);
        }
    }
}
