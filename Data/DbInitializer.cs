using System;
using System.Collections.Generic;
using System.Linq;
using PescaderiaApi.Models;

namespace PescaderiaApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Seed Users
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Id = "1",
                        Email = "maria@example.com",
                        PasswordHash = "password123",
                        Name = "María González",
                        Role = "customer",
                        Phone = "555-1234",
                        Address = "Calle Principal 123, Ciudad"
                    },
                    new User
                    {
                        Id = "2",
                        Email = "juan@example.com",
                        PasswordHash = "password123",
                        Name = "Juan Pérez",
                        Role = "customer",
                        Phone = "555-5678",
                        Address = "Calle Principal 123, Ciudad"
                    },
                    new User
                    {
                        Id = "3",
                        Email = "Pescadria.fernando@gmail.com",
                        PasswordHash = "202609",
                        Name = "Fernando Azcorra",
                        Role = "admin",
                        Phone = "(999) 505-4210",
                        Address = "Calle Pescadores 456, Progreso, Yucatán"
                    }
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            // Seed Products
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new() {
                        Id = "1",
                        Name = "Pescado Empanizado",
                        Description = "Incluye pescado empanizado acompañado de arroz, frijol, tortillas y guarnición.",
                        Price = 120,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Orden"
                    },
                    new() {
                        Id = "2",
                        Name = "Pescado Empanizado",
                        Description = "Incluye arroz, frijol, tortillas y guarnición. La única diferencia es una porción menor de pescado.",
                        Price = 90,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Media Orden"
                    },
                    new() {
                        Id = "3",
                        Name = "Camarón Empanizado",
                        Description = "Incluye camarones empanizados, arroz, frijol, tortillas y guarnición.",
                        Price = 170,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1565680018434-b513d5e5fd47?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Orden"
                    },
                    new() {
                        Id = "4",
                        Name = "Camarón Empanizado",
                        Description = "Incluye arroz, frijol, tortillas y guarnición. La única diferencia es una porción menor de camarones.",
                        Price = 120,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1565680018434-b513d5e5fd47?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Media Orden"
                    },
                    new() {
                        Id = "5",
                        Name = "Cóctel de Camarón (Marisco o Mixto)",
                        Description = "Cóctel preparado de camarón con opción marisco o mixto.",
                        Price = 160,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1534604973900-c43ab4c2e0ab?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Copa"
                    },
                    new() {
                        Id = "6",
                        Name = "Cazón Frito",
                        Description = "Disponible únicamente miércoles y viernes.",
                        Price = 110,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1580476262798-bddd9f4b7369?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Orden"
                    },
                    new() {
                        Id = "7",
                        Name = "Cazón Frito",
                        Description = "Disponible únicamente miércoles y viernes.",
                        Price = 75,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1580476262798-bddd9f4b7369?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Media Orden"
                    },
                    new() {
                        Id = "8",
                        Name = "Cazón Entomatado",
                        Description = "Disponible únicamente miércoles y viernes.",
                        Price = 110,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1580476262798-bddd9f4b7369?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Orden"
                    },
                    new() {
                        Id = "9",
                        Name = "Cazón Entomatado",
                        Description = "Disponible únicamente miércoles y viernes.",
                        Price = 75,
                        Category = "Platillos",
                        Image = "https://images.unsplash.com/photo-1580476262798-bddd9f4b7369?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Media Orden"
                    },
                    new() {
                        Id = "10",
                        Name = "Camarón Fresco Crudo sin Cáscara y Cabeza",
                        Description = "Medida 21/25.",
                        Price = 260,
                        Category = "Mariscos Frescos",
                        Image = "https://images.unsplash.com/photo-1565680018434-b513d5e5fd47?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Kilogramo"
                    },
                    new() {
                        Id = "11",
                        Name = "Camarón Cocido",
                        Description = "Con cabeza. Medida 41/50.",
                        Price = 150,
                        Category = "Mariscos Frescos",
                        Image = "https://images.unsplash.com/photo-1565680018434-b513d5e5fd47?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Kilogramo"
                    },
                    new() {
                        Id = "12",
                        Name = "Cazón Fresco o Rebanado",
                        Description = "Producto fresco listo para preparar.",
                        Price = 120,
                        Category = "Mariscos Frescos",
                        Image = "https://images.unsplash.com/photo-1580476262798-bddd9f4b7369?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Kilogramo"
                    },
                    new() {
                        Id = "13",
                        Name = "Tostada Bolsa Grande",
                        Description = "Contenido de 400 gramos.",
                        Price = 50,
                        Category = "Tostadas",
                        Image = "https://images.unsplash.com/photo-1546069901-ba9599a7e63c?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Bolsa"
                    },
                    new() {
                        Id = "14",
                        Name = "Tostada Bolsa Mediana",
                        Description = "Contenido de 150 gramos.",
                        Price = 18,
                        Category = "Tostadas",
                        Image = "https://images.unsplash.com/photo-1546069901-ba9599a7e63c?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Bolsa"
                    },
                    new() {
                        Id = "15",
                        Name = "Postas de Camarón Fritas",
                        Description = "Venta por kilogramo ya frito.",
                        Price = 360,
                        Category = "Frituras",
                        Image = "https://images.unsplash.com/photo-1625944525533-473f1a3d54e7?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Kilogramo"
                    },
                    new() {
                        Id = "16",
                        Name = "Pescado Frito Corvinal",
                        Description = "Venta por kilogramo.",
                        Price = 330,
                        Category = "Frituras",
                        Image = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Kilogramo"
                    },
                    new() {
                        Id = "17",
                        Name = "Pecho Frito de Mero",
                        Description = "Venta por kilogramo.",
                        Price = 330,
                        Category = "Frituras",
                        Image = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2?w=600&h=400&fit=crop",
                        Available = true,
                        AvailableForPickup = true,
                        AvailableForDelivery = true,
                        Rating = 5.0,
                        Reviews = 0,
                        Weight = "Kilogramo"
                    }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // Seed Orders
            if (!context.Orders.Any())
            {
                var orders = new List<Order>
                {
                    new Order
                    {
                        Id = "ORD-2026-001",
                        UserId = "1",
                        Date = "2026-06-10T10:30:00",
                        Status = "delivered",
                        Items = new List<OrderItem>
                        {
                            new() { ProductId = "1", ProductName = "Camarones Frescos", Quantity = 2, Price = 280 },
                            new() { ProductId = "7", ProductName = "Salmón Noruego", Quantity = 1, Price = 320 }
                        },
                        Subtotal = 880,
                        Tax = 140.80m,
                        Shipping = 0,
                        Total = 1020.80m,
                        PaymentMethod = "credit",
                        ShippingAddress = "Calle Principal 123, Mérida, Yucatán"
                    },
                    new Order
                    {
                        Id = "ORD-2026-002",
                        UserId = "1",
                        Date = "2026-06-12T15:45:00",
                        Status = "shipping",
                        Items = new List<OrderItem>
                        {
                            new() { ProductId = "13", ProductName = "Ceviche de Camarón", Quantity = 3, Price = 180 }
                        },
                        Subtotal = 540,
                        Tax = 86.40m,
                        Shipping = 0,
                        Total = 626.40m,
                        PaymentMethod = "transfer",
                        ShippingAddress = "Calle Principal 123, Mérida, Yucatán"
                    }
                };
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}
