using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_ADONET_WPF_product__11_10_2023
{
    public class String_table_qvery
    {
        // перечисление для выбора таблиц
        public enum table
        {
            product_t,
            supplier_t,
            type_t
        }
        // список для выбора запросов, потом возьмем индекс из combobox
        // и на основе индекса выберем запрос 12-10-2023 16-12
        public string ListString_qvery(int num)
        {
            List<string> list = new List<string>();
            // 0.Отображение всей информации о товаре
           list.Add( "SELECT * from product_t p, type_t t, supplier_t s" +
               " where p.type_id_f = t.id_f and  p.supplier_id_f = s.id_f");
            // 1.Отображение всех типов товаров
            list.Add("SELECT * from  type_t");
            // 2.Отображение всех поставщиков
            list.Add(  "SELECT * from supplier_t ");
            // 3.Показать товар с максимальным количеством
            list.Add("select  p.* from product_t p" +
                " where p.count_f =" +
                "( select max(p2.count_f) from product_t p2 )");
            // 4.Показать товар с минимальным количеством
            list.Add("select  p.* from product_t p" +
                " where p.count_f =" +
                "( select min(p2.count_f) from product_t p2 )");
            // 5.Показать товар с минимальной себестоимостью self_cost_f
            list.Add("select  p.* from product_t p" +
                " where p.self_cost_f =" +
                "( select min(p2.self_cost_f) from product_t p2 )");
            // 6.Показать товар с максимальной себестоимостью self_cost_f
            list.Add("select  p.* from product_t p" +
                " where p.self_cost_f =" +
                "( select max(p2.self_cost_f) from product_t p2 )");
            // 7.Показать товары, заданной категории
            list.Add("7");
            // 8.Показать товары, заданного поставщика
            list.Add("8");
            // 9.Показать самый старый товар на складе date_f
            list.Add("select  p.* from product_t p" +
                 " where p.date_f =" +
                 "( select min(p2.date_f) from product_t p2 )");
            // 10.Показать среднее количество товаров по каждому типу товара avg count
            list.Add("select p.name_f, AVG(p.count_f) " +
                "from product_t p " +
                "group by p.name_f ");
            // 11.резерв  ++
            list.Add("11");
            return list[num];
        }
    }
}
