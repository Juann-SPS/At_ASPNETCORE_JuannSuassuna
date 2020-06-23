using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoPessoa.Models {
    public class Pessoa {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int DiasRestantes { get; set; }
        public int ProximoAniversario() {
            DateTime momento = DateTime.Today;
            DateTime DataAniv = new DateTime(momento.Year, DataNascimento.Month, DataNascimento.Day);

            if (DataAniv < momento) {
                DataAniv = DataAniv.AddYears(1);
            }

            int CalcDiff = (DataAniv - momento).Days;
            return CalcDiff;
        }
    }
}