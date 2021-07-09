CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "operation" (
    "rec_id" INTEGER NOT NULL CONSTRAINT "PK_operation" PRIMARY KEY AUTOINCREMENT,
    "operation_key" TEXT NOT NULL,
    "start_date_time_utc" TEXT NOT NULL,
    "end_date_time_utc" TEXT NOT NULL
);

INSERT INTO "operation" ("rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc")
VALUES (1, '2021-05-29 10:10:00', 'login', '2021-05-29 10:00:00');

INSERT INTO "operation" ("rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc")
VALUES (2, '2021-06-01 10:10:00', 'create_user', '2021-06-01 10:00:00');

INSERT INTO "operation" ("rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc")
VALUES (3, '2021-05-29 10:10:00', 'delete_user', '2021-05-29 10:00:00');

INSERT INTO "operation" ("rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc")
VALUES (4, '2021-05-29 10:10:00', 'create_user', '2021-05-29 10:00:00');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210709180026_1.0.0-init-db', '5.0.7');

COMMIT;

