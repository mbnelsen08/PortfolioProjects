using FlooringMaster.Models.Interfaces;
using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TaxesRepository : ITaxes
    {
        private string _filePath = @"C:\Data\FlooringMastery\Taxes.txt";
        private List<Taxes> data;
        private Taxes convertRowToObject(string[] rows)
        {
            Taxes state = new Taxes();

            state.StateAbbreviation = rows[0];
            state.StateName = rows[1];
            state.TaxRate = decimal.Parse(rows[2]);

            return state;
        }
        public List<Taxes> LoadTaxes()
        {
            data = new List<Taxes>();
            string[] rows = File.ReadAllLines(_filePath);

            for (var i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');
                Taxes state = convertRowToObject(columns);
                data.Add(state);
            }
            return data;
        }
    }
}
