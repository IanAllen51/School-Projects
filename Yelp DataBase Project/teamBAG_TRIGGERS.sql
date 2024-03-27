-- teamBAG
-- https://www.postgresql.org/docs/current/plpgsql-trigger.html
-- https://www.w3resource.com/PostgreSQL/postgresql-triggers.php



-- 5a Whenever a user provides a tip for a business, the “numTips” value for that business and the 
-- “tipCount” value for the user should be updated. 

---- updating user's tipcount
CREATE OR REPLACE FUNCTION updateTipCount()
  RETURNS TRIGGER AS $$
BEGIN
   UPDATE Users
      SET tipcount  = tipcount  + 1
	  WHERE users.userId = NEW.userId;
   RETURN NEW;
END
    $$
LANGUAGE 'plpgsql';

CREATE TRIGGER AddUserTip
        AFTER INSERT OR UPDATE
    ON tip
    FOR EACH ROW
    WHEN (NEW.userId IS NOT NULL)
    EXECUTE PROCEDURE UpdateTipCount();

------ updating business' tipCount
CREATE OR REPLACE FUNCTION updateTipCountB()
  RETURNS TRIGGER AS $$
BEGIN
   UPDATE Business
      SET tipCount  = tipCount  + 1
	  WHERE business.busId = NEW.busId;
   RETURN NEW;
END
    $$
    LANGUAGE 'plpgsql';


CREATE TRIGGER AddBusinessTip
    AFTER INSERT OR UPDATE
    ON tip
    FOR EACH ROW
    WHEN (NEW.busId IS NOT NULL)
    EXECUTE PROCEDURE updateTipCountB();



-- 5b. Similarly, when a customer checks-in a business, the “numCheckins” attribute value for that 
-- business should be updated.

CREATE OR REPLACE FUNCTION updateCheckIn()
    RETURNS TRIGGER AS $$
BEGIN
   UPDATE Business
      SET checkInCount  = checkInCount  + 1
      WHERE busId = NEW.busId;
   RETURN NEW;
    END;
$$
    LANGUAGE 'plpgsql';

CREATE TRIGGER AddCheckIn
AFTER INSERT ON checkIn
FOR EACH ROW
WHEN (NEW.busId IS NOT NULL)
EXECUTE PROCEDURE updateCheckIn();


-- 5c. When a user likes a tip, the “totalLikes” attribute value for the user who wrote that tip should be 
-- updated.

CREATE OR REPLACE FUNCTION updatetotalLikes() 
	RETURNS TRIGGER AS $$
BEGIN
   UPDATE Users
      SET totalLikes = totalLikes + 1
      WHERE userId = NEW.userId;
   RETURN NEW;
END;
$$
    LANGUAGE 'plpgsql';

CREATE TRIGGER totalLike
AFTER UPDATE OF likes ON tip
FOR EACH ROW
WHEN (OLD.likes < NEW.likes)
EXECUTE PROCEDURE updatetotalLikes();




--- TEST for 5a
INSERT INTO tip
VALUES ('5KheTjYPu1HcQzQFtm4_vw', '09owAly0xUSt_JlDVLuNJg', '2022-04-01 01:46:17', 44, 'Good atmosphere or however you spell that word.');


--- TEST for 5b
INSERT INTO checkIn
VALUES ('5KheTjYPu1HcQzQFtm4_vw', 2022, 01, 11, 10:23:11);
	
--- TEST for 5c
INSERT INTO tip
VALUES ('5KheTjYPu1HcQzQFtm4_vw', '09owAly0xUSt_JlDVLuNJg', '2022-04-01 01:46:17', 44, 'Good atmosphere or however you spell that word.');

