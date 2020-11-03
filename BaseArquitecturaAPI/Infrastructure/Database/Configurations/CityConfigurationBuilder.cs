using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class CityConfigurationBuilder : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.CityName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(30)");

            builder
                .Property(v => v.CityCode)
                .HasColumnName("Code")
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder
               .HasOne(v => v.State)
               .WithMany(v => v.Cities)
               .IsRequired()
               .HasConstraintName("FkStateId");

            builder
            .HasData(
            new City { Id = 1, CityName = "Boaco", CityCode = "361", StateId = 1 },
            new City { Id = 2, CityName = "Camoapa", CityCode = "362", StateId = 1 },
            new City { Id = 3, CityName = "Santa Lucía", CityCode = "363", StateId = 1 },
            new City { Id = 4, CityName = "San José del Remate", CityCode = "364", StateId = 1 },
            new City { Id = 5, CityName = "San Lorenzo", CityCode = "365", StateId = 1 },
            new City { Id = 6, CityName = "Teustepe", CityCode = "366", StateId = 1 },

            new City { Id = 7, CityName = "Jinotepe", CityCode = "041", StateId = 2 },
            new City { Id = 8, CityName = "Diriamba", CityCode = "042", StateId = 2 },
            new City { Id = 9, CityName = "San Marcos", CityCode = "043", StateId = 2 },
            new City { Id = 10, CityName = "Santa Teresa", CityCode = "044", StateId = 2 },
            new City { Id = 11, CityName = "Dolores", CityCode = "045", StateId = 2 },
            new City { Id = 12, CityName = "La Paz Carazo", CityCode = "046", StateId = 2 },
            new City { Id = 13, CityName = "El Rosario", CityCode = "047", StateId = 2 },
            new City { Id = 14, CityName = "La Conquista", CityCode = "048", StateId = 2 },

            new City { Id = 15, CityName = "Chinandega", CityCode = "081", StateId = 3 },
            new City { Id = 16, CityName = "Corinto", CityCode = "082", StateId = 3 },
            new City { Id = 17, CityName = "El Realejo", CityCode = "083", StateId = 3 },
            new City { Id = 18, CityName = "Chichigalpa", CityCode = "084", StateId = 3 },
            new City { Id = 19, CityName = "Posoltega", CityCode = "085", StateId = 3 },
            new City { Id = 20, CityName = "El viejo", CityCode = "086", StateId = 3 },
            new City { Id = 21, CityName = "Puerto Morazán", CityCode = "087", StateId = 3 },
            new City { Id = 22, CityName = "Somotillo", CityCode = "088", StateId = 3 },
            new City { Id = 23, CityName = "Villa Nueva", CityCode = "089", StateId = 3 },
            new City { Id = 24, CityName = "Santo Tomás del Norte", CityCode = "090", StateId = 3 },
            new City { Id = 25, CityName = "Cinco Pinos", CityCode = "091", StateId = 3 },
            new City { Id = 26, CityName = "San Fransisco del Norte", CityCode = "092", StateId = 3 },
            new City { Id = 27, CityName = "San Pedro del Norte", CityCode = "093", StateId = 3 },

            new City { Id = 28, CityName = "Juigalpa", CityCode = "121", StateId = 4 },
            new City { Id = 29, CityName = "Acoyapa", CityCode = "122", StateId = 4 },
            new City { Id = 30, CityName = "Santo Tomás", CityCode = "123", StateId = 4 },
            new City { Id = 31, CityName = "Villa Sandino", CityCode = "124", StateId = 4 },
            new City { Id = 32, CityName = "San Pedro de Lóvago", CityCode = "125", StateId = 4 },
            new City { Id = 33, CityName = "La Libertad", CityCode = "126", StateId = 4 },
            new City { Id = 34, CityName = "Santo Domingo", CityCode = "127", StateId = 4 },
            new City { Id = 35, CityName = "Comalapa", CityCode = "128", StateId = 4 },
            new City { Id = 36, CityName = "San Fransisco Cuapa", CityCode = "129", StateId = 4 },
            new City { Id = 37, CityName = "El Coral", CityCode = "130", StateId = 4 },

            new City { Id = 38, CityName = "Estelí", CityCode = "161", StateId = 5 },
            new City { Id = 39, CityName = "Pueblo Nuevo", CityCode = "162", StateId = 5 },
            new City { Id = 40, CityName = "Condega", CityCode = "163", StateId = 5 },
            new City { Id = 41, CityName = "San Juan Limay", CityCode = "164", StateId = 5 },
            new City { Id = 42, CityName = "La Trinidad", CityCode = "165", StateId = 5 },
            new City { Id = 43, CityName = "San Nícolas", CityCode = "166", StateId = 5 },

            new City { Id = 44, CityName = "Granada", CityCode = "201", StateId = 6 },
            new City { Id = 45, CityName = "Nandaime", CityCode = "202", StateId = 6 },
            new City { Id = 46, CityName = "Diriomo", CityCode = "203", StateId = 6 },
            new City { Id = 47, CityName = "Diría", CityCode = "204", StateId = 6 },

            new City { Id = 48, CityName = "Jinotega", CityCode = "241", StateId = 7 },
            new City { Id = 49, CityName = "San Rafael del Norte", CityCode = "242", StateId = 7 },
            new City { Id = 50, CityName = "San Sebastián Yalí", CityCode = "243", StateId = 7 },
            new City { Id = 51, CityName = "La Concordia", CityCode = "244", StateId = 7 },
            new City { Id = 52, CityName = "San José de Bocay", CityCode = "245", StateId = 7 },
            new City { Id = 53, CityName = "El Cuá Bocay", CityCode = "246", StateId = 7 },
            new City { Id = 54, CityName = "Santa María Pantasma", CityCode = "247", StateId = 7 },

             new City { Id = 55, CityName = "León", CityCode = "281", StateId = 8 },
             new City { Id = 56, CityName = "El Jicaral", CityCode = "283", StateId = 8 },
             new City { Id = 57, CityName = "La Paz Centro", CityCode = "284", StateId = 8 },
             new City { Id = 58, CityName = "Santa Rosa del Peñón", CityCode = "285", StateId = 8 },
             new City { Id = 59, CityName = "Quetzalguaque", CityCode = "286", StateId = 8 },
             new City { Id = 60, CityName = "Nagarote", CityCode = "287", StateId = 8 },
             new City { Id = 61, CityName = "El Sauce", CityCode = "288", StateId = 8 },
             new City { Id = 62, CityName = "Achuapa", CityCode = "289", StateId = 8 },
             new City { Id = 63, CityName = "Telica", CityCode = "290", StateId = 8 },
             new City { Id = 64, CityName = "Larreynaga Malpaisillo", CityCode = "291", StateId = 8 },


             new City { Id = 65, CityName = "Somoto", CityCode = "321", StateId = 9 },
             new City { Id = 66, CityName = "Telpaneca", CityCode = "322", StateId = 9 },
             new City { Id = 67, CityName = "San Juan Rio Coco", CityCode = "323", StateId = 9 },
             new City { Id = 68, CityName = "Palacagüina", CityCode = "324", StateId = 9 },
             new City { Id = 69, CityName = "Yalagüina", CityCode = "325", StateId = 9 },
             new City { Id = 70, CityName = "Totogalpa", CityCode = "326", StateId = 9 },
             new City { Id = 71, CityName = "San Lucas", CityCode = "327", StateId = 9 },
             new City { Id = 72, CityName = "La Sabanas", CityCode = "328", StateId = 9 },
             new City { Id = 73, CityName = "San José de Cusmapa", CityCode = "329", StateId = 9 },

             new City { Id = 74, CityName = "Managua", CityCode = "001", StateId = 10 },
             new City { Id = 75, CityName = "San Rafael del Sur", CityCode = "002", StateId = 10 },
             new City { Id = 76, CityName = "Tipitapa", CityCode = "003", StateId = 10 },
             new City { Id = 77, CityName = "Villa Carlos Fonseca", CityCode = "004", StateId = 10 },
             new City { Id = 78, CityName = "San Fransisco Libre", CityCode = "005", StateId = 10 },
             new City { Id = 79, CityName = "Mateare", CityCode = "006", StateId = 10 },
             new City { Id = 80, CityName = "Ticuantepe", CityCode = "007", StateId = 10 },
             new City { Id = 81, CityName = "Ciudad Sandino", CityCode = "008", StateId = 10 },
             new City { Id = 82, CityName = "El Crucero", CityCode = "009", StateId = 10 },

             new City { Id = 83, CityName = "Masaya", CityCode = "401", StateId = 11 },
             new City { Id = 84, CityName = "Nindirí", CityCode = "402", StateId = 11 },
             new City { Id = 85, CityName = "Tisma", CityCode = "403", StateId = 11 },
             new City { Id = 86, CityName = "Catarina", CityCode = "404", StateId = 11 },
             new City { Id = 87, CityName = "San Juan de Oriente", CityCode = "405", StateId = 11 },
             new City { Id = 88, CityName = "Niquinohomo", CityCode = "406", StateId = 11 },
             new City { Id = 89, CityName = "Nandasmo", CityCode = "407", StateId = 11 },
             new City { Id = 90, CityName = "Masatepe", CityCode = "408", StateId = 11 },
             new City { Id = 91, CityName = "La Concepción", CityCode = "409", StateId = 11 },


             new City { Id = 92, CityName = "Matagalpa", CityCode = "441", StateId = 12 },
             new City { Id = 93, CityName = "San Ramón", CityCode = "442", StateId = 12 },
             new City { Id = 94, CityName = "Matiguás", CityCode = "443", StateId = 12 },
             new City { Id = 95, CityName = "Muy Muy", CityCode = "444", StateId = 12 },
             new City { Id = 96, CityName = "Esquipulas", CityCode = "445", StateId = 12 },
             new City { Id = 97, CityName = "San Dionisio", CityCode = "446", StateId = 12 },
             new City { Id = 98, CityName = "San Isidro", CityCode = "447", StateId = 12 },
             new City { Id = 99, CityName = "Sébaco", CityCode = "448", StateId = 12 },
             new City { Id = 100, CityName = "Ciudad Darío", CityCode = "449", StateId = 12 },
             new City { Id = 101, CityName = "Terrabona", CityCode = "450", StateId = 12 },
             new City { Id = 102, CityName = "Río Blanco", CityCode = "451", StateId = 12 },
             new City { Id = 103, CityName = "Tuma La Dalia", CityCode = "452", StateId = 12 },
             new City { Id = 104, CityName = "Rancho Grande", CityCode = "453", StateId = 12 },

             new City { Id = 105, CityName = "Ocotal", CityCode = "481", StateId = 13 },
             new City { Id = 106, CityName = "Santa María", CityCode = "482", StateId = 13 },
             new City { Id = 107, CityName = "Macuelizo", CityCode = "483", StateId = 13 },
             new City { Id = 108, CityName = "Dipilto", CityCode = "484", StateId = 13 },
             new City { Id = 109, CityName = "Ciudad Antigua", CityCode = "485", StateId = 13 },
             new City { Id = 110, CityName = "Mozonte", CityCode = "486", StateId = 13 },
             new City { Id = 111, CityName = "San Fernando", CityCode = "487", StateId = 13 },
             new City { Id = 112, CityName = "El Jícaro", CityCode = "488", StateId = 13 },
             new City { Id = 113, CityName = "Jalapa", CityCode = "489", StateId = 13 },
             new City { Id = 114, CityName = "Murra", CityCode = "490", StateId = 13 },
             new City { Id = 115, CityName = "Quilalí", CityCode = "491", StateId = 13 },
             new City { Id = 116, CityName = "Wiwilí", CityCode = "492", StateId = 13 },
             new City { Id = 117, CityName = "Wiwilí Nueva Segovia", CityCode = "493", StateId = 13 },

             new City { Id = 118, CityName = "San Carlos", CityCode = "521", StateId = 14 },
             new City { Id = 119, CityName = "El Castillo", CityCode = "522", StateId = 14 },
             new City { Id = 120, CityName = "San Miguelito", CityCode = "523", StateId = 14 },
             new City { Id = 121, CityName = "Morrito", CityCode = "524", StateId = 14 },
             new City { Id = 122, CityName = "San Juan del Norte", CityCode = "525", StateId = 14 },
             new City { Id = 123, CityName = "El Almendro", CityCode = "526", StateId = 14 },

             new City { Id = 124, CityName = "Rivas", CityCode = "561", StateId = 15 },
             new City { Id = 125, CityName = "San Jorge", CityCode = "562", StateId = 15 },
             new City { Id = 126, CityName = "Buenos Aires", CityCode = "563", StateId = 15 },
             new City { Id = 127, CityName = "Potosí", CityCode = "564", StateId = 15 },
             new City { Id = 128, CityName = "Belén", CityCode = "565", StateId = 15 },
             new City { Id = 129, CityName = "Tola", CityCode = "566", StateId = 15 },
             new City { Id = 130, CityName = "San Juan del Sur", CityCode = "567", StateId = 15 },
             new City { Id = 131, CityName = "Cárdenas", CityCode = "568", StateId = 15 },
             new City { Id = 132, CityName = "Moyogalpa", CityCode = "569", StateId = 15 },
             new City { Id = 133, CityName = "Altagracia", CityCode = "570", StateId = 15 }
            );
        }
    }                       
}
