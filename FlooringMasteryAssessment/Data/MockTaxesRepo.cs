using FlooringMaster.Models.Interfaces;
using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MockTaxesRepo : ITaxes
    {
        List<Taxes> taxes = new List<Taxes>()
        {
            new Taxes() {StateAbbreviation="OH",StateName="Ohio",TaxRate=6.25M},
            new Taxes() {StateAbbreviation="PA",StateName="Pennsylvania",TaxRate=6.75M},
            new Taxes() {StateAbbreviation="MI",StateName="Michigan",TaxRate=5.75M},
            new Taxes() {StateAbbreviation="IN",StateName="Indiana",TaxRate=6.00M},
        };
        public List<Taxes> LoadTaxes()
        {
            return taxes;
        }
    }
}
