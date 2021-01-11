using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class agregandoPaisesCiudades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "varchar(30)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "Name", "StateId" },
                values: new object[,]
                {
                    { 2, "362", "Camoapa", 1 },
                    { 3, "363", "Santa Lucía", 1 },
                    { 4, "364", "San José del Remate", 1 },
                    { 5, "365", "San Lorenzo", 1 },
                    { 6, "366", "Teustepe", 1 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 13, 1, "Nueva Segovia" },
                    { 12, 1, "Matagalpa" },
                    { 11, 1, "Masaya" },
                    { 10, 1, "Managua" },
                    { 9, 1, "Madriz" },
                    { 8, 1, "León" },
                    { 6, 1, "Granada" },
                    { 14, 1, "Río San Juan" },
                    { 5, 1, "Estelí" },
                    { 4, 1, "Chontales" },
                    { 3, 1, "Chinandega" },
                    { 2, 1, "Carazo" },
                    { 7, 1, "Jinotega" },
                    { 15, 1, "Rivas" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "Name", "StateId" },
                values: new object[,]
                {
                    { 7, "041", "Jinotepe", 2 },
                    { 99, "448", "Sébaco", 12 },
                    { 98, "447", "San Isidro", 12 },
                    { 97, "446", "San Dionisio", 12 },
                    { 96, "445", "Esquipulas", 12 },
                    { 95, "444", "Muy Muy", 12 },
                    { 94, "443", "Matiguás", 12 },
                    { 93, "442", "San Ramón", 12 },
                    { 92, "441", "Matagalpa", 12 },
                    { 91, "409", "La Concepción", 11 },
                    { 90, "408", "Masatepe", 11 },
                    { 89, "407", "Nandasmo", 11 },
                    { 88, "406", "Niquinohomo", 11 },
                    { 87, "405", "San Juan de Oriente", 11 },
                    { 100, "449", "Ciudad Darío", 12 },
                    { 86, "404", "Catarina", 11 },
                    { 84, "402", "Nindirí", 11 },
                    { 83, "401", "Masaya", 11 },
                    { 82, "009", "El Crucero", 10 },
                    { 81, "008", "Ciudad Sandino", 10 },
                    { 80, "007", "Ticuantepe", 10 },
                    { 79, "006", "Mateare", 10 },
                    { 78, "005", "San Fransisco Libre", 10 },
                    { 77, "004", "Villa Carlos Fonseca", 10 },
                    { 76, "003", "Tipitapa", 10 },
                    { 75, "002", "San Rafael del Sur", 10 },
                    { 74, "001", "Managua", 10 },
                    { 73, "329", "San José de Cusmapa", 9 },
                    { 72, "328", "La Sabanas", 9 },
                    { 85, "403", "Tisma", 11 },
                    { 71, "327", "San Lucas", 9 },
                    { 101, "450", "Terrabona", 12 },
                    { 103, "452", "Tuma La Dalia", 12 },
                    { 131, "568", "Cárdenas", 15 },
                    { 130, "567", "San Juan del Sur", 15 },
                    { 129, "566", "Tola", 15 },
                    { 128, "565", "Belén", 15 },
                    { 127, "564", "Potosí", 15 },
                    { 126, "563", "Buenos Aires", 15 },
                    { 125, "562", "San Jorge", 15 },
                    { 124, "561", "Rivas", 15 },
                    { 123, "526", "El Almendro", 14 },
                    { 122, "525", "San Juan del Norte", 14 },
                    { 121, "524", "Morrito", 14 },
                    { 120, "523", "San Miguelito", 14 },
                    { 119, "522", "El Castillo", 14 },
                    { 102, "451", "Río Blanco", 12 },
                    { 118, "521", "San Carlos", 14 },
                    { 116, "492", "Wiwilí", 13 },
                    { 115, "491", "Quilalí", 13 },
                    { 114, "490", "Murra", 13 },
                    { 113, "489", "Jalapa", 13 },
                    { 112, "488", "El Jícaro", 13 },
                    { 111, "487", "San Fernando", 13 },
                    { 110, "486", "Mozonte", 13 },
                    { 109, "485", "Ciudad Antigua", 13 },
                    { 108, "484", "Dipilto", 13 },
                    { 107, "483", "Macuelizo", 13 },
                    { 106, "482", "Santa María", 13 },
                    { 105, "481", "Ocotal", 13 },
                    { 104, "453", "Rancho Grande", 12 },
                    { 117, "493", "Wiwilí Nueva Segovia", 13 },
                    { 132, "569", "Moyogalpa", 15 },
                    { 70, "326", "Totogalpa", 9 },
                    { 68, "324", "Palacagüina", 9 },
                    { 35, "128", "Comalapa", 4 },
                    { 34, "127", "Santo Domingo", 4 },
                    { 33, "126", "La Libertad", 4 },
                    { 32, "125", "San Pedro de Lóvago", 4 },
                    { 31, "124", "Villa Sandino", 4 },
                    { 30, "123", "Santo Tomás", 4 },
                    { 29, "122", "Acoyapa", 4 },
                    { 28, "121", "Juigalpa", 4 },
                    { 27, "093", "San Pedro del Norte", 3 },
                    { 26, "092", "San Fransisco del Norte", 3 },
                    { 25, "091", "Cinco Pinos", 3 },
                    { 24, "090", "Santo Tomás del Norte", 3 },
                    { 23, "089", "Villa Nueva", 3 },
                    { 36, "129", "San Fransisco Cuapa", 4 },
                    { 22, "088", "Somotillo", 3 },
                    { 20, "086", "El viejo", 3 },
                    { 19, "085", "Posoltega", 3 },
                    { 18, "084", "Chichigalpa", 3 },
                    { 17, "083", "El Realejo", 3 },
                    { 16, "082", "Corinto", 3 },
                    { 15, "081", "Chinandega", 3 },
                    { 14, "048", "La Conquista", 2 },
                    { 13, "047", "El Rosario", 2 },
                    { 12, "046", "La Paz Carazo", 2 },
                    { 11, "045", "Dolores", 2 },
                    { 10, "044", "Santa Teresa", 2 },
                    { 9, "043", "San Marcos", 2 },
                    { 8, "042", "Diriamba", 2 },
                    { 21, "087", "Puerto Morazán", 3 },
                    { 69, "325", "Yalagüina", 9 },
                    { 37, "130", "El Coral", 4 },
                    { 39, "162", "Pueblo Nuevo", 5 },
                    { 67, "323", "San Juan Rio Coco", 9 },
                    { 66, "322", "Telpaneca", 9 },
                    { 65, "321", "Somoto", 9 },
                    { 64, "291", "Larreynaga Malpaisillo", 8 },
                    { 63, "290", "Telica", 8 },
                    { 62, "289", "Achuapa", 8 },
                    { 61, "288", "El Sauce", 8 },
                    { 60, "287", "Nagarote", 8 },
                    { 59, "286", "Quetzalguaque", 8 },
                    { 58, "285", "Santa Rosa del Peñón", 8 },
                    { 57, "284", "La Paz Centro", 8 },
                    { 56, "283", "El Jicaral", 8 },
                    { 55, "281", "León", 8 },
                    { 38, "161", "Estelí", 5 },
                    { 54, "247", "Santa María Pantasma", 7 },
                    { 52, "245", "San José de Bocay", 7 },
                    { 51, "244", "La Concordia", 7 },
                    { 50, "243", "San Sebastián Yalí", 7 },
                    { 49, "242", "San Rafael del Norte", 7 },
                    { 48, "241", "Jinotega", 7 },
                    { 47, "204", "Diría", 6 },
                    { 46, "203", "Diriomo", 6 },
                    { 45, "202", "Nandaime", 6 },
                    { 44, "201", "Granada", 6 },
                    { 43, "166", "San Nícolas", 5 },
                    { 42, "165", "La Trinidad", 5 },
                    { 41, "164", "San Juan Limay", 5 },
                    { 40, "163", "Condega", 5 },
                    { 53, "246", "El Cuá Bocay", 7 },
                    { 133, "570", "Altagracia", 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 20);
        }
    }
}
