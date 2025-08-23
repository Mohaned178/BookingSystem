using System;
using EfCore.Services;
using EfCore.Models;

namespace EfCore.UI
{
    public static class BookingSystem
    {
        public static void Run()
        {
            var userService = new UserService();
            var resourceService = new ResourceService();
            var reservationService = new ReservationService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Booking System ====");
                Console.WriteLine("1. Manage Users");
                Console.WriteLine("2. Manage Resources");
                Console.WriteLine("3. Manage Reservations");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageUsers(userService);
                        break;
                    case "2":
                        ManageResources(resourceService);
                        break;
                    case "3":
                        ManageReservations(reservationService);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, press Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // ==================== USERS ====================
        private static void ManageUsers(UserService userService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Users Menu ===");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. List Users");
                Console.WriteLine("3. Update User");
                Console.WriteLine("4. Delete User");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Email: ");
                        var email = Console.ReadLine();
                        Console.Write("Role: ");
                        var role = Console.ReadLine();
                        userService.CreateUser(name, email, role);
                        Console.WriteLine("User created!");
                        Console.ReadLine();
                        break;
                    case "2":
                        foreach (var u in userService.GetAllUsers())
                            Console.WriteLine($"{u.Id} - {u.Name} - {u.Email} - {u.Role}");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("User Id: ");
                        var uid = int.Parse(Console.ReadLine());
                        Console.Write("New Name: ");
                        var newName = Console.ReadLine();
                        Console.Write("New Email: ");
                        var newEmail = Console.ReadLine();
                        Console.Write("New Role: ");
                        var newRole = Console.ReadLine();
                        userService.UpdateUser(uid, newName, newEmail, newRole);
                        Console.WriteLine("User updated!");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Write("User Id: ");
                        var did = int.Parse(Console.ReadLine());
                        userService.DeleteUser(did);
                        Console.WriteLine("User deleted!");
                        Console.ReadLine();
                        break;
                    case "0": return;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // ==================== RESOURCES ====================
        private static void ManageResources(ResourceService resourceService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Resources Menu ===");
                Console.WriteLine("1. Add Resource");
                Console.WriteLine("2. List Resources");
                Console.WriteLine("3. Update Resource");
                Console.WriteLine("4. Delete Resource");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Type: ");
                        var type = Console.ReadLine();
                        var res = new Resource { Name = name, Type = type };
                        resourceService.AddResource(res);
                        Console.WriteLine("Resource created!");
                        Console.ReadLine();
                        break;
                    case "2":
                        foreach (var r in resourceService.GetAllResources())
                            Console.WriteLine($"{r.Id} - {r.Name} - {r.Type}");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Resource Id: ");
                        var rid = int.Parse(Console.ReadLine());
                        var resource = resourceService.GetResourceById(rid);
                        if (resource != null)
                        {
                            Console.Write("New Name: ");
                            resource.Name = Console.ReadLine();
                            Console.Write("New Type: ");
                            resource.Type = Console.ReadLine();
                            resourceService.UpdateResource(resource);
                            Console.WriteLine("Resource updated!");
                        }
                        else Console.WriteLine("Not found!");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Write("Resource Id: ");
                        var did = int.Parse(Console.ReadLine());
                        resourceService.DeleteResource(did);
                        Console.WriteLine("Resource deleted!");
                        Console.ReadLine();
                        break;
                    case "0": return;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // ==================== RESERVATIONS ====================
        private static void ManageReservations(ReservationService reservationService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Reservations Menu ===");
                Console.WriteLine("1. Add Reservation");
                Console.WriteLine("2. List Reservations");
                Console.WriteLine("3. Update Reservation");
                Console.WriteLine("4. Delete Reservation");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("UserId: ");
                        var uid = int.Parse(Console.ReadLine());
                        Console.Write("ResourceId: ");
                        var rid = int.Parse(Console.ReadLine());
                        Console.Write("Start Time (yyyy-mm-dd HH:mm): ");
                        var start = DateTime.Parse(Console.ReadLine());
                        Console.Write("End Time (yyyy-mm-dd HH:mm): ");
                        var end = DateTime.Parse(Console.ReadLine());
                        Console.Write("Status (Pending/Confirmed/Cancelled): ");
                        var status = Console.ReadLine();

                        var res = new Reservation
                        {
                            UserId = uid,
                            ResourceId = rid,
                            StartTime = start,
                            EndTime = end,
                            Status = status
                        };

                        reservationService.AddReservation(res);
                        Console.WriteLine("Reservation created!");
                        Console.ReadLine();
                        break;

                    case "2":
                        foreach (var r in reservationService.GetAllReservations())
                        {
                            Console.WriteLine($"{r.Id} - User:{r.UserId} - Resource:{r.ResourceId} - {r.StartTime} → {r.EndTime} - Status:{r.Status}");
                        }
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Reservation Id: ");
                        var id = int.Parse(Console.ReadLine());
                        var reservation = reservationService.GetReservationById(id);
                        if (reservation != null)
                        {
                            Console.Write("New Start Time (yyyy-mm-dd HH:mm): ");
                            reservation.StartTime = DateTime.Parse(Console.ReadLine());
                            Console.Write("New End Time (yyyy-mm-dd HH:mm): ");
                            reservation.EndTime = DateTime.Parse(Console.ReadLine());
                            Console.Write("New Status (Pending/Confirmed/Cancelled): ");
                            reservation.Status = Console.ReadLine();

                            reservationService.UpdateReservation(reservation);
                            Console.WriteLine("Reservation updated!");
                        }
                        else
                        {
                            Console.WriteLine("Reservation not found!");
                        }
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Write("Reservation Id: ");
                        var did = int.Parse(Console.ReadLine());
                        reservationService.DeleteReservation(did);
                        Console.WriteLine("Reservation deleted!");
                        Console.ReadLine();
                        break;

                    case "0": return;

                    default:
                        Console.WriteLine("Invalid choice");
                        Console.ReadLine();
                        break;
                }
            }
        }

    }
}
