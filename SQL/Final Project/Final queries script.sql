use zzcars;
/*IQ1
Drop view  custbalance;
CREATE VIEW custbalance AS 
         SELECT Customer_ID,Remaining_Balance, 
               IF(Remaining_Balance<50,null,Remaining_Balance)  as itemCost
                FROM billingdetails;     
        SELECT count(*) FROM custbalance;
-- IQ2
drop view custnameswbalance;
create view custnameswbalance AS
	select customer.customer_name, bill_number, remaining_balance,
		if(remaining_balance<0, null,remaining_balance)
    from Customer cross join BillingDetails;
    
    select count(*)
    from custnameswbalance;*/
    
    -- IQ3
    