﻿using ProjectMvc.Models;


using ProjectMvc.Models.Enuns;

namespace ProjectMvc.Data
{
    public class SeedingService
    {
        private ProjectMvcContext _context;

        public SeedingService(ProjectMvcContext context)
        {
            _context = context;
        }

        public object SaleStatus { get; private set; }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Saller.Any() || _context.SalesRecords.Any()) // testa se a algum registro
            {
                return; // banco de dados já foi populado

            }
            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");
            Saller s1 = new Saller(1, "Bob brown", "Bob@gmail.com", new DateTime(2000, 4, 21), 1000.0, d1);
            Saller s2 = new Saller(2, "Maria Santos", "MariaSantos@gmail.com", new DateTime(2001, 4, 3), 2000.0, d2);
            Saller s3 = new Saller(3, "Camila Oliveira", "CamilaOliveira@gmail.com", new DateTime(1999, 4, 2), 3000.0, d3);
            Saller s4 = new Saller(4, "Marta de Jesus", "MartaJesus@gmail.com", new DateTime(2003, 4, 9), 1500.0, d4);
            Saller s5 = new Saller(5, "Carla Matos", "CarlaMatos@gmail.com", new DateTime(2002, 4, 1), 1600.0, d2);
            Saller s6 = new Saller(6, "Marlon Azevedo ", "MarlonAzevedo@gmail.com", new DateTime(2001, 4, 01), 1100.0, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2025, 6, 5), 11000, SalesStatus.Billed, s1);
            
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 4), 7000.0, SalesStatus.Billed, s5);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 13), 4000.0, SalesStatus.Canceled, s4);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 1), 8000.0, SalesStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 21), 3000.0, SalesStatus.Billed, s3);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 15), 2000.0, SalesStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 09, 28), 13000.0, SalesStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 09, 11), 4000.0, SalesStatus.Billed, s4);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 09, 14), 11000.0, SalesStatus.Pending, s6);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 09, 7), 9000.0, SalesStatus.Billed, s6);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 09, 13), 6000.0, SalesStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 09, 25), 7000.0, SalesStatus.Pending, s3);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 09, 29), 10000.0, SalesStatus.Billed, s4);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2018, 09, 4), 3000.0, SalesStatus.Billed, s5);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2018, 09, 12), 4000.0, SalesStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2018, 10, 5), 2000.0, SalesStatus.Billed, s4);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2018, 10, 1), 12000.0, SalesStatus.Billed, s1);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2018, 10, 24), 6000.0, SalesStatus.Billed, s3);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2018, 10, 22), 8000.0, SalesStatus.Billed, s5);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2018, 10, 15), 8000.0, SalesStatus.Billed, s6);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2018, 10, 17), 9000.0, SalesStatus.Billed, s2);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2018, 10, 24), 4000.0, SalesStatus.Billed, s4);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2018, 10, 19), 11000.0, SalesStatus.Canceled, s2);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2018, 10, 12), 8000.0, SalesStatus.Billed, s5);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2018, 10, 31), 7000.0, SalesStatus.Billed, s3);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2018, 10, 6), 5000.0, SalesStatus.Billed, s4);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2018, 10, 13), 9000.0, SalesStatus.Pending, s1);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2018, 10, 7), 4000.0, SalesStatus.Billed, s3);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2018, 10, 23), 12000.0, SalesStatus.Billed, s5);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2018, 10, 12), 5000.0, SalesStatus.Billed, s2);


            //inclusão dos objetos no banco de dados
            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Saller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecords.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );
            _context.SaveChanges();
        }
    }
}
