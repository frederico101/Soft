namespace Soft.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSeedBooksTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), '1984', 'George Orwell', 'Dystopian', 0, NOW(), NOW(), 'Available', '/images/book2.jpeg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Pride and Prejudice', 'Jane Austen', 'Romance', 0, NOW(), NOW(), 'Available', '/images/book2.jpeg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Great Gatsby', 'F. Scott Fitzgerald', 'Fiction', 0, NOW(), NOW(), 'Available', '/images/book2.jpeg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Moby Dick', 'Herman Melville', 'Adventure', 0, NOW(), NOW(), 'Available', '/images/book5.jpeg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'War and Peace', 'Leo Tolstoy', 'Historical', 0, NOW(), NOW(), 'Available', '/images/book5.jpeg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 0, NOW(), NOW(), 'Available', '/images/book5.jpeg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Lord of the Rings', 'J.R.R. Tolkien', 'Fantasy', 0, NOW(), NOW(), 'Available', '/images/book5.jpeg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Hobbit', 'J.R.R. Tolkien', 'Fantasy', 0, NOW(), NOW(), 'Available', '/images/book4.webp')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Jane Eyre', 'Charlotte Brontë', 'Romance', 0, NOW(), NOW(), 'Available', '/images/book4.webp')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Wuthering Heights', 'Emily Brontë', 'Romance', 0, NOW(), NOW(), 'Available', '/images/book4.webp')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Brave New World', 'Aldous Huxley', 'Dystopian', 0, NOW(), NOW(), 'Available', '/images/book4.webp')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Odyssey', 'Homer', 'Epic', 0, NOW(), NOW(), 'Available', '/images/book4.webp')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Les Misérables', 'Victor Hugo', 'Historical', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Picture of Dorian Gray', 'Oscar Wilde', 'Fiction', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Brothers Karamazov', 'Fyodor Dostoevsky', 'Philosophical', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Crime and Punishment', 'Fyodor Dostoevsky', 'Psychological', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Don Quixote', 'Miguel de Cervantes', 'Adventure', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'The Divine Comedy', 'Dante Alighieri', 'Epic', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
            Sql("INSERT INTO Books (Id, Title, Author, Category, IsRented, CreatedAt, UpdatedAt, Status, CoverPath) VALUES (UUID(), 'Frankenstein', 'Mary Shelley', 'Horror', 0, NOW(), NOW(), 'Available', '/images/book18.jpg')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Books");

        }
    }
}
