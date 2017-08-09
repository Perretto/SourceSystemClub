using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemClub.Models
{
    [Table("Socio")]
    public class Socio
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid idSocio { get; set; }

        [Column("NomeSocio")]
        [StringLength(200)]
        [Display(Name = "Nome do socio")]
        public virtual string NomeSocio { get; set; }

        [Column("Sexo")]
        [StringLength(15)]
        [Display(Name = "Sexo do socio")]
        public virtual string Sexo { get; set; }

        [Column("Categoria")]
        [StringLength(30)]
        [Display(Name = "Categoria do titulo")]
        public virtual string Categoria { get; set; }

        [Column("CPF")]
        [StringLength(20)]
        [Display(Name = "CPF do titular")]
        public virtual string CPF { get; set; }

        [Column("RG")]
        [StringLength(20)]
        [Display(Name = "RG do titular")]
        public virtual string RG { get; set; }

        [Column("DTNasc")]
        [Display(Name = "Data de nascimento do titular")]
        public virtual DateTime? DtNasc { get; set; }

        [Column("CertCasamento")]
        [StringLength(70)]
        [Display(Name = "Certidao de casamento do titular")]
        public virtual string CertCasa { get; set; }

        [Column("Profissao")]
        [StringLength(70)]
        [Display(Name = "Profissao do titular")]
        public virtual string Profissao { get; set; }

        [Column("EstadoCivil")]
        [StringLength(50)]
        [Display(Name = "Estado civil do titular")]
        public virtual string EstCivil { get; set; }

        [Column("Convenio")]
        [Display(Name = "Convenio")]
        public virtual Guid Convenio { get; set; }

        [Column("ValorMensalidade")]
        [Display(Name = "Valor da Mensalidade")]
        public virtual decimal ValMensalidade { get; set; }

        [Column("DiaVencimento")]
        [Display(Name = "Dia do vencimento da mensalidade")]
        public virtual int DiaVenc { get; set; }

        [Column("DataCompra")]
        [Display(Name = "Data da aquisicao do titulo")]
        public virtual DateTime? DataCompra { get; set; }

        [Column("Telefone1")]
        [StringLength(20)]
        [Display(Name = "Telefone 1")]
        public virtual string Tel1 { get; set; }

        [Column("Telefone2")]
        [StringLength(50)]
        [Display(Name = "Telefone 2")]
        public virtual string Tel2 { get; set; }

        [Column("Email")]
        [StringLength(200)]
        [Display(Name = "Email do titular")]
        public virtual string Email { get; set; }

        [Column("NomePai")]
        [StringLength(20)]
        [Display(Name = "Nome do pai do titular")]
        public virtual string NomePai { get; set; }

        [Column("NomeMae")]
        [StringLength(200)]
        [Display(Name = "Nome da mae do titular")]
        public virtual string NomeMae { get; set; }

        [Column("DocFalta", TypeName = "varchar(MAX)")]
        [Display(Name = "Documentos pendentes")]
        public virtual string DocFalta { get; set; }

        [Column("Informacao", TypeName = "varchar(MAX)")]
        [Display(Name = "Informacoes")]
        public virtual string Informacao { get; set; }

        [NotMapped]
        public virtual List<Guid> Dependente { get; set; }
        [NotMapped]
        public virtual List<Guid> Agregado { get; set; }

    }

}