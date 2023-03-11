ALTER TABLE "public"."resk_project_person" DROP CONSTRAINT "FK_resk_project_person_project_id";
ALTER TABLE "public"."resk_project_person" DROP CONSTRAINT "fkey_person_project";
DROP TABLE IF EXISTS "public"."resk_project";
DROP TABLE IF EXISTS "public"."resk_project_person";
DROP TABLE IF EXISTS "public"."resk_person";
CREATE TABLE "public"."resk_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "resk_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."resk_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "resk_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."resk_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "resk_person_pkey" PRIMARY KEY ("id")
);
ALTER TABLE "public"."resk_project" DISABLE TRIGGER ALL;
ALTER TABLE "public"."resk_project_person" DISABLE TRIGGER ALL;
ALTER TABLE "public"."resk_person" DISABLE TRIGGER ALL;
INSERT INTO "public"."resk_project" ("project_name") VALUES ('c#');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('c++');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('c#');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('ecomerce');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('SQL');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('MySql');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('f#');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('MSQL');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('miniproject');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('OOP');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('postman');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('R');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('HTML');
INSERT INTO "public"."resk_project" ("project_name") VALUES ('miniproject');
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (8, 9, 10);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (7, 7, 12);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (6, 3, 3);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (5, 1, 3);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (4, 10, 4);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (12, 2, 4);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (12, 10, 4);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (4, 13, 3);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (2, 2, 7);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (2, 1, 33);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 4);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 4);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 4);
INSERT INTO "public"."resk_project_person" ("project_id", "person_id", "hours") VALUES (9, 1, 10);
INSERT INTO "public"."resk_person" ("person_name") VALUES ('reza');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('rasoul ');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('Reza');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('ali');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('krille');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('kjs');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('resk');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('kristian');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('eskandar');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('alex');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('ali');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('hashem');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('mohammad');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('ilias');
INSERT INTO "public"."resk_person" ("person_name") VALUES ('reza');
ALTER TABLE "public"."resk_project" ENABLE TRIGGER ALL;
ALTER TABLE "public"."resk_project_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."resk_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."resk_project_person" ADD CONSTRAINT "FK_resk_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."resk_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."resk_project_person" ADD CONSTRAINT "fkey_person_project" FOREIGN KEY ("person_id") REFERENCES "public"."resk_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
