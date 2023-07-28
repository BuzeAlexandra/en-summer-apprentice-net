using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TMSapi.Models;

public partial class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<TotalNumberOfTicketsPerCategory> TotalNumberOfTicketsPerCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Project;User Id=SA;Password=Buze2201;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK_Event");

            entity.ToTable("Event");

            entity.Property(e => e.EventId)
                //.ValueGeneratedNever()
                .HasColumnName("eventId");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eventDescription");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.EventTypeId).HasColumnName("eventTypeId");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.VenueId).HasColumnName("venueId");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_EventType");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_Venue");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.ToTable("EventType");

            entity.Property(e => e.EventTypeId)
                //.ValueGeneratedNever()
                .HasColumnName("eventTypeId");
            entity.Property(e => e.EventTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eventTypeName");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId)
                //.ValueGeneratedNever()
                .HasColumnName("orderId");
            entity.Property(e => e.NumberOfTickets).HasColumnName("numberOfTickets");
            entity.Property(e => e.OrderedAt)
                .HasPrecision(6)
                .HasColumnName("orderedAt");
            entity.Property(e => e.TicketCategoryId).HasColumnName("ticketCategoryId");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.TicketCategory).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Ticket_Category");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.ToTable("Ticket_Category");

            entity.Property(e => e.TicketCategoryId)
                //.ValueGeneratedNever()
                .HasColumnName("ticketCategoryId");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Ticket_Category_Event");
        });

        modelBuilder.Entity<TotalNumberOfTicketsPerCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_number_of_tickets_per_category");

            entity.Property(e => e.NumberOfSoldTickets).HasColumnName("number_of_sold_tickets");
            entity.Property(e => e.TicketCategoryId).HasColumnName("ticket_category_id");
            entity.Property(e => e.TotalPriceOnCategory).HasColumnName("total_price_on_category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                //.ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.ToTable("Venue");

            entity.Property(e => e.VenueId)
               // .ValueGeneratedNever()
                .HasColumnName("venueId");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
