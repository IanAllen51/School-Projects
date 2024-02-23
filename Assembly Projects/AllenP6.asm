#AllenP6
#
#TESTING:
#	Initial testing for user pin showed that PIN value was returned not the address. After swapping registers, the correct
#	address was returned. All PINS were tested with success. 1111, 2222, 3024, and 9999 were tested and correctly displayed
#	the incorrect PIN prompt. GetBalance displayed correct Balance for all nodes. MakeWithdrawal correctly displayed and 
#	stored new balance when less than balance. After finding that i had a string address with similar name to branch label 
#	and made appropriate changes, the function correctly displayed results for less than, greater than, and equal vaues.




#Constants
.eqv PRINT_INT 1
.eqv PRINT_STR 4
.eqv READ_INT 5
.eqv NL 10
.eqv TERMINATE 10
.eqv PRINT_CHAR 11


.eqv BALANCE 4
.eqv NEXT_CUST 8
.eqv CUST_NAME 12


        .data
PinCall: .asciiz "Please enter your FOUR digit PIN: "
UserWelcome: .asciiz "Welcome "
UserWelcomeEnd: .asciiz "!"
DenyUser: .asciiz "Incorrect PIN. Good Bye!"
BalancePrompt: .asciiz "Your balance is: "
WithdrawalPrompt: .asciiz "How much would you like to withdraw?: "
NewBalance: .asciiz "Your new balance is: "
Over: .asciiz "No loans, just withdrawals..."
        
        
	.align 2	# Align what follows in a 4-byte boundary
head:
cust0:	.word 1234	# PIN
	.word 525	# Balance
	.word cust1	# Pointer to next customer info
	.asciiz "Abel"	# Customer name
	
cust1:  .word 2341
	.word 43
        .word cust2
	.asciiz "Bernard"
	        
cust2:  .word 1176
	.word 10250	    
        .word cust3
	.asciiz "Charlie" 
	       
cust3:  .word 3025
	.word 10        
        .word cust4
	.asciiz "Douglas"
	        
cust4:  .word 6172
	.word 810         
        .word cust5
	.asciiz "Elvin"  
	      
cust5:  .word 8890
	.word 25         
        .word cust6
	.asciiz "Frodo"  
	      
cust6:  .word 4049
	.word 75         
        .word cust7
	.asciiz "George"       
	 
cust7:  .word 2170
	.word 320         
        .word cust8
	.asciiz "Homer"
	        
cust8:  .word 3081
	.word 1024         
        .word cust9
	.asciiz "Ishmael"   
	     
cust9:  .word 1009
	.word 615         
        .word cust10
	.asciiz "Jess"  
	      
cust10: .word 1011
	.word 15
        .word custEND
	.asciiz "Keith"
	        
custEND: .word 0



	.text
main:
	#Call For User Pin
	la $a0, PinCall
	li $v0, PRINT_STR
	syscall
	
	#User Pin Input
	li $v0, READ_INT
	syscall
	
	#Prepare for FindCustomer
	move $a3, $v0				#Store user pin in register $a3
	move $a1, $a3
	la $a0, head				#Store address of list head
	
	#call FindCustomer
	jal FindCustomer
	
	#store return value
	move $t0, $v0				#store customer address in $t0
	
	#print Results
	beq $t0, $0, NoPin			#branch if PIN was not found
	la $a0, UserWelcome
	li $v0, PRINT_STR
	syscall
	
	add $t1, $t0, CUST_NAME			#offset to name address
	la $a0, ($t1)				#store name addresss
	li $v0, PRINT_STR
	syscall
	
	la $a0, UserWelcomeEnd
	li $v0, PRINT_STR
	syscall
	
	la $a0, NL
	li $v0, PRINT_CHAR
	syscall
	
	j NameEnd
NoPin:
	la $a0, DenyUser
	li $v0, PRINT_STR
	syscall
	
	li $v0, TERMINATE
	syscall
	
NameEnd:

	#Set up for GetBalance
	la $a0, head
	move $a1, $a3				#move user PIN into $a1
	
	#call GetBalance
	jal GetBalance
	
	#store GetBalance results
	move $t1, $v0
	
	#print balance prompt
	la $a0, BalancePrompt
	li $v0, PRINT_STR
	syscall
	
	#print balance
	move $a0, $t1
	li $v0, PRINT_INT
	syscall
	
	la $a0, NL
	li $v0, PRINT_CHAR
	syscall
	
	#call for user withdrawal amount
	la $a0, WithdrawalPrompt
	li $v0, PRINT_STR
	syscall
	
	#gather withdrawal amount
	li $v0, READ_INT
	syscall
	
	#set up for MakeWithdrawal
	la $a0, head
	move $a1, $a3				#move user PIN to a1
	move $a2, $v0				#move Withdrawal amouint to a2
	
	#call MakeWithdrawal
	jal MakeWithdrawal
	
	#End Program
	li $v0, TERMINATE
	syscall




#----------------------------------------------------------------------------------------------------------------------
#FindCustomer-search via linked list to match customer PIN
#Parameters:
#	$a0: Contains the address of the head of the list
#	$a1: Contains the customers PIN
#Return Value:
#	$v0: Contains the address of the customers node or zero if not present.
#Additional Registers Used:
#	$t0: Contains the PIN at the given node
#	$t1: Contains the current address of the PIN register
#	$t2: acts as a temporary register for the updated address of linked nodes
#
#----------------------------------------------------------------------------------------------------------------------

FindCustomer:
	lw $t0, ($a0)
	move $t1, $a0				#store list address in temporary register
	#li $t1, 0
Find:
	beq $t0, $0, WrongPin			#branch if pin is not found in linked list
	beq $t0, $a1, FinishFind		#branch to the end if matched pin is found
	add $t1, $t1, NEXT_CUST			#increment address by 8 to the location of the next node
	lw $t2, ($t1)				#load pin of next node into $t0
	lw $t0, ($t2)
	move $t1, $t2
	j Find
	
WrongPin:
	li $v0, 0
	j EndFind
	
FinishFind:
	move $v0, $t1
	j EndFind
	
EndFind:
	jr $ra

#----------------------------------------------------------------------------------------------------------------------
#GetBalance- Will call FindCustomer to get address and then will return balance of given node
#Parameters:
#	$a0: Contains the address of the head of the list
#	$a1: Contains the users PIN
#Return Value:
#	$v0: Contains the balance in the given node
#Other Registers Used:
#	$sp: Stack at base 0 contains the ra of GetBalance while running FindCustomer
#	$t0: Contains the address of the customer PIN and then the updated address of customer Balance
#
#----------------------------------------------------------------------------------------------------------------------

GetBalance:
	addi $sp, $sp, -4
	sw $ra ($sp)
	
	jal FindCustomer
	
	lw $ra ($sp)
	addi $sp, $sp, 4
	
	move $t0, $v0			#move node addresss to t0
	add $t0, $t0, BALANCE
	lw $v0, ($t0)
	
	jr $ra
#----------------------------------------------------------------------------------------------------------------------
#MakeWithdrawal- Will call FindCustomer and then will use withdrawal amount to decrement balance or prompt a fail message
#Parameters:
#	$a0: Contains the address of the head of the list
#	$a1: Contains the User PIN
#	$a2: Contains the user prompted withdrawal amount
#ReturnValue:
#	No registers will be returned, but the balance or fail message will be printed.
#Other Register Used:
# 	$sp: Contains the address of $ra while FindCustomer is being run
#	$t0: Contains the address of returned pin and then address of the given node's Balance
#	$t1: Contains the amount stored in the given node's Balance address 
#
#----------------------------------------------------------------------------------------------------------------------

MakeWithdrawal:
	
	addi $sp, $sp, -4
	sw $ra ($sp)
	
	jal FindCustomer
	
	lw $ra ($sp)
	addi $sp, $sp, 4

	move $t0, $v0			#move node address to t0
	add $t0, $t0, BALANCE
	lw $t1, ($t0)			#load the balance value
	
	blt $t1, $a2, OverDraw		#if balance is less than withdrawal amount, branch
	sub $t1, $t1, $a2		#find difference between balance and withdrawal
	sw $t1, ($t0)			#update the balance with the new balance
	
	la $a0, NewBalance
	li $v0, PRINT_STR
	syscall
	
	move $a0, $t1
	li $v0, PRINT_INT
	syscall
	
	j WithdrawalEnd
	
OverDraw:
	la $a0, Over
	li $v0, PRINT_STR
	syscall
	
WithdrawalEnd:
	jr $ra
#----------------------------------------------------------------------------------------------------------------------





