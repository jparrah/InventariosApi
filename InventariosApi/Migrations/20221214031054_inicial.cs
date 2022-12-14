using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventariosApi.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defectaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDefectacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defectaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLabor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSucursal = table.Column<int>(type: "int", nullable: false),
                    NombreSucursal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CI = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEquipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoEquipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEquipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    TipoEquipoId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    Inventario = table.Column<long>(type: "bigint", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Depreciacion = table.Column<float>(type: "real", nullable: false),
                    Sello = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_TipoEquipos_TipoEquipoId",
                        column: x => x.TipoEquipoId,
                        principalTable: "TipoEquipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquiposDefectados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    TipoEquipoId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    Inventario = table.Column<long>(type: "bigint", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Depreciacion = table.Column<float>(type: "real", nullable: false),
                    DefectacionId = table.Column<int>(type: "int", nullable: false),
                    Sello = table.Column<long>(type: "bigint", nullable: false),
                    FechaReparada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquiposDefectados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquiposDefectados_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquiposDefectados_Defectaciones_DefectacionId",
                        column: x => x.DefectacionId,
                        principalTable: "Defectaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquiposDefectados_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquiposDefectados_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquiposDefectados_TipoEquipos_TipoEquipoId",
                        column: x => x.TipoEquipoId,
                        principalTable: "TipoEquipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquiposId = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquiposDefectadosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componentes_Equipos_EquiposId",
                        column: x => x.EquiposId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Componentes_EquiposDefectados_EquiposDefectadosId",
                        column: x => x.EquiposDefectadosId,
                        principalTable: "EquiposDefectados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquiposDefectadosLabores",
                columns: table => new
                {
                    EquiposDefectadosId = table.Column<int>(type: "int", nullable: false),
                    LaboresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquiposDefectadosLabores", x => new { x.EquiposDefectadosId, x.LaboresId });
                    table.ForeignKey(
                        name: "FK_EquiposDefectadosLabores_EquiposDefectados_EquiposDefectadosId",
                        column: x => x.EquiposDefectadosId,
                        principalTable: "EquiposDefectados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquiposDefectadosLabores_Labores_LaboresId",
                        column: x => x.LaboresId,
                        principalTable: "Labores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquiposDefectadosId = table.Column<int>(type: "int", nullable: true),
                    TecnicoId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: true),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fundamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_EquiposDefectados_EquiposDefectadosId",
                        column: x => x.EquiposDefectadosId,
                        principalTable: "EquiposDefectados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ordenes_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ordenes_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquiposBajas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    EquiposDefectadosId = table.Column<int>(type: "int", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquiposBajas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquiposBajas_EquiposDefectados_EquiposDefectadosId",
                        column: x => x.EquiposDefectadosId,
                        principalTable: "EquiposDefectados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquiposBajas_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_EquiposDefectadosId",
                table: "Componentes",
                column: "EquiposDefectadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_EquiposId",
                table: "Componentes",
                column: "EquiposId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_AreaId",
                table: "Equipos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_EstadoId",
                table: "Equipos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_SucursalId",
                table: "Equipos",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_TipoEquipoId",
                table: "Equipos",
                column: "TipoEquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposBajas_EquiposDefectadosId",
                table: "EquiposBajas",
                column: "EquiposDefectadosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquiposBajas_OrdenId",
                table: "EquiposBajas",
                column: "OrdenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquiposDefectados_AreaId",
                table: "EquiposDefectados",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposDefectados_DefectacionId",
                table: "EquiposDefectados",
                column: "DefectacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposDefectados_EstadoId",
                table: "EquiposDefectados",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposDefectados_SucursalId",
                table: "EquiposDefectados",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposDefectados_TipoEquipoId",
                table: "EquiposDefectados",
                column: "TipoEquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposDefectadosLabores_LaboresId",
                table: "EquiposDefectadosLabores",
                column: "LaboresId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EquiposDefectadosId",
                table: "Ordenes",
                column: "EquiposDefectadosId",
                unique: true,
                filter: "[EquiposDefectadosId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_SucursalId",
                table: "Ordenes",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_TecnicoId",
                table: "Ordenes",
                column: "TecnicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "EquiposBajas");

            migrationBuilder.DropTable(
                name: "EquiposDefectadosLabores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Labores");

            migrationBuilder.DropTable(
                name: "EquiposDefectados");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Defectaciones");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "TipoEquipos");
        }
    }
}
