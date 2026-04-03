using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace trilha_net_api_mvc_desafio.Models.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}