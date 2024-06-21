﻿using KhumaloCrafting___.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace KhumaloCrafting___.Repositories
{
    public class ProductRepository
    {
        private readonly KhumaloCraft_Context _context;

        public ProductRepository(KhumaloCraft_Context context)
        {
            _context = context;
        }

        public void InsertProducts()
        {
            // Define the SQL query for inserting products
            var sqlQuery = @"
                INSERT INTO Products (name, description, price, category, image_url)
                VALUES 
                    ('Vibrant Beaded Earring', 'A pair of exquisite handcrafted beaded earrings, featuring a vibrant blend of colors and intricate patterns.', 100.00, 'jewelry', '~/images/product1.jpg'),
                    ('Carved African Elephant Mask Wall Hanging', 'These hand-carved wooden elephant sculptures add the earthy, exotic feel of safari lodge decor to your home.', 500.00, 'homedecor', '~/images/product2.webp'),
                    ('“Cream Collection” Folded Bowl', 'This folded bowl is part of my popular “Cream Collection” range. It is decorated with sgraffito lines which reveal the creamy colour of the clay.', 440.00, 'pottery', '~/images/product3.jpg')";

            // Execute the SQL query
            _context.Database.ExecuteSqlRaw(sqlQuery);
        }
    }
}