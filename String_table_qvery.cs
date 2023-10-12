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
            // Отображение всей информации о товаре
            string zero = "SELECT * from product_t p, type_t, supplier_t ";
            // Отображение всех типов товаров
            string first = "SELECT * from  type_t";
            // Отображение всех поставщиков
            string second = "SELECT * from supplier_t ";
            // Показать товар с максимальным количеством
            string thild = "select max (p.count_f) from product_t p";
            // Показать товар с минимальным количеством
            string fourth = "select min (p.count_f) from product_t p";
            // Показать товар с минимальной себестоимостью self_cost_f
            string fifth = "select min (p.self_cost_f) from product_t p";
            // Показать товар с максимальной себестоимостью self_cost_f
            string sixth = "select max (p.self_cost_f) from product_t p";
            // Показать товары, заданной категории
            string seventh = "7";
            // Показать товары, заданного поставщика
            string eighth = "8";
            // Показать самый старый товар на складе date_f
            string ninth = "9";
            // Показать среднее количество товаров по каждому типу товара avg count
            string tenth = "10";
            // резерв  ++
            string eleven = "11";

            list.Add(zero);
            list.Add(first);
            list.Add(second);
            list.Add(thild);
            list.Add(fourth);
            list.Add(fifth);
            list.Add(sixth);
            list.Add(seventh);
            list.Add(eighth);
            list.Add(ninth);
            list.Add(tenth);
            list.Add(eleven);
            return list[num];
        }
    }
}
