CREATE DATABASE CoffeeShopDb
GO
USE CoffeeShopDb
GO
CREATE TABLE Products
(
    Id int PRIMARY KEY IDENTITY,
    Name nvarchar(max),
    Detail nvarchar(max),
    ImgUrl nvarchar(max),
    Price decimal(18,2),
    IsTrendingProduct bit
);
DROP TABLE Products;
USE CoffeeShopDb
GO
