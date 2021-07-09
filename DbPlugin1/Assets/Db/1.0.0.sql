CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "user" (
    "user_id" INTEGER NOT NULL CONSTRAINT "PK_user" PRIMARY KEY AUTOINCREMENT,
    "login" TEXT NOT NULL,
    "first_name" TEXT NOT NULL,
    "last_name" TEXT NOT NULL,
    "email" TEXT NOT NULL,
    "city" TEXT NULL
);

INSERT INTO "user" ("user_id", "city", "email", "first_name", "last_name", "login")
VALUES (1, NULL, 'super@test.com', 'Super', 'Superowski', 'super');

INSERT INTO "user" ("user_id", "city", "email", "first_name", "last_name", "login")
VALUES (2, NULL, 'admin@test.com', 'Admin', 'Adminowski', 'admin');

CREATE INDEX "IX_user_login" ON "user" ("login");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210709175401_1.0.0-init-db', '5.0.7');

COMMIT;

