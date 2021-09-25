using System;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FarmApp.Infra.Data.Context
{
    public partial class Db_FarmAppContext : DbContext
    {
        public Db_FarmAppContext()
        {
        }

        public Db_FarmAppContext(DbContextOptions<Db_FarmAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApresentacaoProdutoPoco> ApresentacaoProdutos { get; set; }
        public virtual DbSet<BairroPoco> Bairros { get; set; }
        public virtual DbSet<CepPoco> Ceps { get; set; }
        public virtual DbSet<CidadePoco> Cidades { get; set; }
        public virtual DbSet<ClientePoco> Clientes { get; set; }
        public virtual DbSet<ConsentimentoPoco> Consentimentos { get; set; }
        public virtual DbSet<ContaFarmaciaPoco> ContaFarmacia { get; set; }
        public virtual DbSet<ContaMensagemSistemaPoco> ContaMensagemSistemas { get; set; }
        public virtual DbSet<ContaPessoalPoco> ContaPessoals { get; set; }
        public virtual DbSet<ContaPoco> Conta { get; set; }
        public virtual DbSet<EnderecoPoco> Enderecos { get; set; }
        public virtual DbSet<EnderecoContapessoalPoco> EnderecoContapessoals { get; set; }
        public virtual DbSet<ItemClientePoco> ItemClientes { get; set; }
        public virtual DbSet<ItemFarmaciaPoco> ItemFarmacia { get; set; }
        public virtual DbSet<MarcaPoco> Marcas { get; set; }
        public virtual DbSet<MensagemSistemaPoco> MensagemSistemas { get; set; }
        public virtual DbSet<MidiaPoco> Midia { get; set; }
        public virtual DbSet<MotivoPoco> Motivos { get; set; }
        public virtual DbSet<PesquisaPrecoPoco> PesquisaPrecos { get; set; }
        public virtual DbSet<PesquisaPrecoFarmaciaPoco> PesquisaPrecoFarmacia { get; set; }
        public virtual DbSet<ProdutoPoco> Produtos { get; set; }
        public virtual DbSet<ProdutoMarcaPoco> ProdutoMarcas { get; set; }
        public virtual DbSet<ProdutoTipoPoco> ProdutoTipos { get; set; }
        public virtual DbSet<TipoEnderecoPoco> TipoEnderecos { get; set; }
        public virtual DbSet<UfPoco> Ufs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=35.222.117.54;port=3306;database=db_farmapp;uid=root;password=Ftec@2021", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.34-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<ApresentacaoProdutoPoco>(new ApresentacaoProdutoMapping().Configure);

            modelBuilder.Entity<BairroPoco>(new BairroMapping().Configure);

            modelBuilder.Entity<CepPoco>(new CepMapping().Configure);

            modelBuilder.Entity<CidadePoco>(new CidadeMapping().Configure);

            modelBuilder.Entity<ClientePoco>(entity =>
            {
                entity.ToTable("cliente");

                entity.HasIndex(e => e.Idconta, "fk_cliente_conta1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .HasColumnName("celular");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");

                entity.Property(e => e.Idconta)
                    .HasColumnType("int(11)")
                    .HasColumnName("idconta");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("senha");

                entity.Property(e => e.ValidaEmail)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("valida_email");

                entity.HasOne(d => d.IdcontaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Idconta)
                    .HasConstraintName("fk_cliente_conta1");
            });

            modelBuilder.Entity<ConsentimentoPoco>(new ConsentimentoMapping().Configure);

            modelBuilder.Entity<ContaFarmaciaPoco>(entity =>
            {
                entity.ToTable("conta_farmacia");

                entity.HasIndex(e => e.Idcep, "fk_conta_farmacia_cep1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Alvara)
                    .HasMaxLength(20)
                    .HasColumnName("alvara");

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .HasColumnName("celular");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(200)
                    .HasColumnName("endereco");

                entity.Property(e => e.Idcep)
                    .HasColumnType("int(11)")
                    .HasColumnName("idcep");

                entity.Property(e => e.LatilongFarmacia)
                    .HasMaxLength(16)
                    .HasColumnName("latilong_farmacia");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(100)
                    .HasColumnName("nome_fantasia");

                entity.Property(e => e.NumeroEndereçofarmacia)
                    .HasMaxLength(10)
                    .HasColumnName("numero_endereçofarmacia");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(100)
                    .HasColumnName("razao_social");

                entity.Property(e => e.Site)
                    .HasMaxLength(200)
                    .HasColumnName("site");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdcepNavigation)
                    .WithMany(p => p.ContaFarmacia)
                    .HasForeignKey(d => d.Idcep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_conta_farmacia_cep1");
            });

            modelBuilder.Entity<ContaMensagemSistemaPoco>(entity =>
            {
                entity.ToTable("conta_mensagem_sistema");

                entity.HasIndex(e => e.Idconta, "fk_conta1_idx");

                entity.HasIndex(e => e.IdmensagemSistema, "fk_mensagem_sistema1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Idconta)
                    .HasColumnType("int(11)")
                    .HasColumnName("idconta");

                entity.Property(e => e.IdmensagemSistema)
                    .HasColumnType("int(11)")
                    .HasColumnName("idmensagem_sistema");

                entity.HasOne(d => d.IdcontaNavigation)
                    .WithMany(p => p.ContaMensagemSistemas)
                    .HasForeignKey(d => d.Idconta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_conta1");

                entity.HasOne(d => d.IdmensagemSistemaNavigation)
                    .WithMany(p => p.ContaMensagemSistemas)
                    .HasForeignKey(d => d.IdmensagemSistema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mensagem_sistema1");
            });

            modelBuilder.Entity<ContaPessoalPoco>(new ContaPessoalMapping().Configure);

            modelBuilder.Entity<ContaPoco>(new ContaMapping().Configure);

            modelBuilder.Entity<EnderecoPoco>(new EnderecoMapping().Configure);

            modelBuilder.Entity<EnderecoContapessoalPoco>(new EnderecoContaPessoalMapping().Configure);

            modelBuilder.Entity<ItemClientePoco>(new ItemClienteMapping().Configure);

            modelBuilder.Entity<ItemFarmaciaPoco>(entity =>
            {
                entity.ToTable("item_farmacia");

                entity.HasIndex(e => e.IdcontaFarmacia, "fk_item_farmacia_conta_farmacia1_idx");

                entity.HasIndex(e => e.IdprodutoMarca, "fk_item_farmacia_produto_marca1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CodigoItemFarmacia)
                    .HasMaxLength(20)
                    .HasColumnName("codigo_item_farmacia");

                entity.Property(e => e.IdcontaFarmacia)
                    .HasColumnType("int(11)")
                    .HasColumnName("idconta_farmacia");

                entity.Property(e => e.IdprodutoMarca)
                    .HasColumnType("int(11)")
                    .HasColumnName("idproduto_marca");

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.HasOne(d => d.IdcontaFarmaciaNavigation)
                    .WithMany(p => p.ItemFarmacia)
                    .HasForeignKey(d => d.IdcontaFarmacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_farmacia_conta_farmacia1");

                entity.HasOne(d => d.IdprodutoMarcaNavigation)
                    .WithMany(p => p.ItemFarmacia)
                    .HasForeignKey(d => d.IdprodutoMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_farmacia_produto_marca1");
            });

            modelBuilder.Entity<MarcaPoco>(new MarcaMapping().Configure);

            modelBuilder.Entity<MensagemSistemaPoco>(entity =>
            {
                entity.ToTable("mensagem_sistema");

                entity.HasIndex(e => e.Idmidia, "fk_mensagem_sistema_midia1_idx");

                entity.HasIndex(e => e.Idmotivo, "fk_mensagem_sistema_motivo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Datahora)
                    .HasColumnType("datetime")
                    .HasColumnName("datahora");

                entity.Property(e => e.Idmidia)
                    .HasColumnType("int(11)")
                    .HasColumnName("idmidia");

                entity.Property(e => e.Idmotivo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idmotivo");

                entity.Property(e => e.Mensagdescricao)
                    .HasMaxLength(255)
                    .HasColumnName("mensagdescricao");

                entity.HasOne(d => d.IdmidiaNavigation)
                    .WithMany(p => p.MensagemSistemas)
                    .HasForeignKey(d => d.Idmidia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mensagem_sistema_midia1");

                entity.HasOne(d => d.IdmotivoNavigation)
                    .WithMany(p => p.MensagemSistemas)
                    .HasForeignKey(d => d.Idmotivo)
                    .HasConstraintName("fk_mensagem_sistema_motivo1");
            });

            modelBuilder.Entity<MidiaPoco>(entity =>
            {
                entity.ToTable("midia");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(45)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<MotivoPoco>(entity =>
            {
                entity.ToTable("motivo");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(45)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<PesquisaPrecoPoco>(entity =>
            {
                entity.ToTable("pesquisa_preco");

                entity.HasIndex(e => e.Idcliente, "fk_pesquisa_cliente1_idx");

                entity.HasIndex(e => e.IditemCliente, "fk_pesquisa_preco_item_cliente1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DataHora)
                    .HasColumnType("datetime")
                    .HasColumnName("data_hora");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idcliente");

                entity.Property(e => e.IditemCliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("iditem_cliente");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.PesquisaPrecos)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pesquisa_cliente1");

                entity.HasOne(d => d.IditemClienteNavigation)
                    .WithMany(p => p.PesquisaPrecos)
                    .HasForeignKey(d => d.IditemCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pesquisa_preco_item_cliente1");
            });

            modelBuilder.Entity<PesquisaPrecoFarmaciaPoco>(entity =>
            {
                entity.ToTable("pesquisa_preco_farmacia");

                entity.HasIndex(e => e.IditemFarmacia, "fk_pesquisa_preco_farmacia_item_farmacia1_idx");

                entity.HasIndex(e => e.Idpesquisa, "fk_pesquisa_preco_farmacia_pesquisa_preco1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IditemFarmacia)
                    .HasColumnType("int(11)")
                    .HasColumnName("iditem_farmacia");

                entity.Property(e => e.Idpesquisa)
                    .HasColumnType("int(11)")
                    .HasColumnName("idpesquisa");

                entity.HasOne(d => d.IditemFarmaciaNavigation)
                    .WithMany(p => p.PesquisaPrecoFarmacia)
                    .HasForeignKey(d => d.IditemFarmacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pesquisa_preco_farmacia_item_farmacia1");

                entity.HasOne(d => d.IdpesquisaNavigation)
                    .WithMany(p => p.PesquisaPrecoFarmacia)
                    .HasForeignKey(d => d.Idpesquisa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pesquisa_preco_farmacia_pesquisa_preco1");
            });

            modelBuilder.Entity<ProdutoPoco>(new ProdutoMapping().Configure);

            modelBuilder.Entity<ProdutoMarcaPoco>(new ProdutoMarcaMapping().Configure);

            modelBuilder.Entity<ProdutoTipoPoco>(new ProdutoTipoMapping().Configure);

            modelBuilder.Entity<TipoEnderecoPoco>(new TipoEnderecoMapping().Configure);

            modelBuilder.Entity<UfPoco>(new UfMapping().Configure);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
