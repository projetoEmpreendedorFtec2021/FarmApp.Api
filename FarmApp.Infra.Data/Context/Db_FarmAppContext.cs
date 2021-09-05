using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<ApresentacaoProduto> ApresentacaoProdutos { get; set; }
        public virtual DbSet<Bairro> Bairros { get; set; }
        public virtual DbSet<Cep> Ceps { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Consentimento> Consentimentos { get; set; }
        public virtual DbSet<ContaFarmacia> ContaFarmacia { get; set; }
        public virtual DbSet<ContaMensagemSistema> ContaMensagemSistemas { get; set; }
        public virtual DbSet<ContaPessoal> ContaPessoals { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<EnderecoContapessoal> EnderecoContapessoals { get; set; }
        public virtual DbSet<ItemCliente> ItemClientes { get; set; }
        public virtual DbSet<ItemFarmacia> ItemFarmacia { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<MensagemSistema> MensagemSistemas { get; set; }
        public virtual DbSet<Midia> Midia { get; set; }
        public virtual DbSet<Motivo> Motivos { get; set; }
        public virtual DbSet<PesquisaPreco> PesquisaPrecos { get; set; }
        public virtual DbSet<PesquisaPrecoFarmacia> PesquisaPrecoFarmacia { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutoMarca> ProdutoMarcas { get; set; }
        public virtual DbSet<ProdutoTipo> ProdutoTipos { get; set; }
        public virtual DbSet<TipoEndereco> TipoEnderecos { get; set; }
        public virtual DbSet<Uf> Ufs { get; set; }

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

            modelBuilder.Entity<ApresentacaoProduto>(entity =>
            {
                entity.ToTable("apresentacao_produto");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DescricaoApresentação)
                    .HasMaxLength(30)
                    .HasColumnName("descricao_apresentação");
            });

            modelBuilder.Entity<Bairro>(new BairroMapping().Configure);

            modelBuilder.Entity<Cep>(new CepMapping().Configure);

            modelBuilder.Entity<Cidade>(new CidadeMapping().Configure);

            modelBuilder.Entity<Cliente>(new ClienteMapping().Configure);

            modelBuilder.Entity<Consentimento>(new ConsentimentoMapping().Configure);

            modelBuilder.Entity<ContaFarmacia>(entity =>
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

            modelBuilder.Entity<ContaMensagemSistema>(entity =>
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

            modelBuilder.Entity<ContaPessoal>(new ContaPessoalMapping().Configure);

            modelBuilder.Entity<Conta>(new ContaMapping().Configure);

            modelBuilder.Entity<Endereco>(new EnderecoMapping().Configure);

            modelBuilder.Entity<EnderecoContapessoal>(new EnderecoContaPessoalMapping().Configure);

            modelBuilder.Entity<ItemCliente>(entity =>
            {
                entity.ToTable("item_cliente");

                entity.HasIndex(e => e.Idcliente, "fk_item_cliente_cliente1_idx");

                entity.HasIndex(e => e.IdprodutoMarca, "fk_item_cliente_produto_marca1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idcliente");

                entity.Property(e => e.IdprodutoMarca)
                    .HasColumnType("int(11)")
                    .HasColumnName("idproduto_marca");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.ItemClientes)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_cliente_cliente1");

                entity.HasOne(d => d.IdprodutoMarcaNavigation)
                    .WithMany(p => p.ItemClientes)
                    .HasForeignKey(d => d.IdprodutoMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_cliente_produto_marca1");
            });

            modelBuilder.Entity<ItemFarmacia>(entity =>
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

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marca");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NomeMarca)
                    .HasMaxLength(50)
                    .HasColumnName("nome_marca");
            });

            modelBuilder.Entity<MensagemSistema>(entity =>
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

            modelBuilder.Entity<Midia>(entity =>
            {
                entity.ToTable("midia");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(45)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Motivo>(entity =>
            {
                entity.ToTable("motivo");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(45)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<PesquisaPreco>(entity =>
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

            modelBuilder.Entity<PesquisaPrecoFarmacia>(entity =>
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

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.HasIndex(e => e.IdprodutoTipo, "fk_produto_produto_tipo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DescricaoProduto)
                    .HasMaxLength(255)
                    .HasColumnName("descricao_produto");

                entity.Property(e => e.IdprodutoTipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idproduto_tipo");

                entity.HasOne(d => d.IdprodutoTipoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdprodutoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_produto_tipo1");
            });

            modelBuilder.Entity<ProdutoMarca>(entity =>
            {
                entity.ToTable("produto_marca");

                entity.HasIndex(e => e.IdapresentacaoProduto, "fk_produto_marca_apresentacao_produto1_idx");

                entity.HasIndex(e => e.Idmarca, "fk_produto_marca_marca1_idx");

                entity.HasIndex(e => e.Idproduto, "fk_produto_marca_produto1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CodigoProdutoMarca)
                    .HasMaxLength(20)
                    .HasColumnName("codigo_produto_marca");

                entity.Property(e => e.IdapresentacaoProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("idapresentacao_produto");

                entity.Property(e => e.Idmarca)
                    .HasColumnType("int(11)")
                    .HasColumnName("idmarca");

                entity.Property(e => e.Idproduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("idproduto");

                entity.HasOne(d => d.IdapresentacaoProdutoNavigation)
                    .WithMany(p => p.ProdutoMarcas)
                    .HasForeignKey(d => d.IdapresentacaoProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_marca_apresentacao_produto1");

                entity.HasOne(d => d.IdmarcaNavigation)
                    .WithMany(p => p.ProdutoMarcas)
                    .HasForeignKey(d => d.Idmarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_marca_marca1");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.ProdutoMarcas)
                    .HasForeignKey(d => d.Idproduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_marca_produto1");
            });

            modelBuilder.Entity<ProdutoTipo>(entity =>
            {
                entity.ToTable("produto_tipo");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DescricaoTipoProduto)
                    .HasMaxLength(45)
                    .HasColumnName("descricao_tipo_produto");
            });

            modelBuilder.Entity<TipoEndereco>(new TipoEnderecoMapping().Configure);

            modelBuilder.Entity<Uf>(new UfMapping().Configure);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
