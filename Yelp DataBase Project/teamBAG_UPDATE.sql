--- “numCheckins”, “numTips”, “totalLikes”, and “tipCount” for each business

UPDATE Business
SET checkInCount = (SELECT COUNT(busId)
                        FROM checkIn 
                        WHERE checkIn.busId = business.busId);
--- UPDATE 19983


UPDATE business
SET tipCount = (SELECT COUNT(busId)
                    FROM tip 
                    WHERE tip.busId = business.busId);		
--- UPDATE 19983

UPDATE users
SET totalLikes = (SELECT SUM(tip.likes)
                    FROM tip
                    WHERE users.userID = tip.userID
GROUP BY userID);

UPDATE users
SET tipcount = (SELECT COUNT(*)
                    FROM tip
                    WHERE users.userID = tip.userID
GROUP BY userID);
