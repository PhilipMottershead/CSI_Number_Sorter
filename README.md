# CSI_Number_Sorter

Candidates are required to build an **MVC** application, using **C#** for code behind and targeting the **latest (stable) version of dotNET Core**. The application will require a **MS SQL database1** for storage of data generated by the application. 

This application must perform the following tasks and built to best practices: 
1. Allow the user to enter a **variable amount of numbers**, of any **integer** value and in **random order**. 
	- [x] Allows a undefined length of input
	- [x] Accepts Integer values
		- [x] Min Max must be interger size
		- [x] Negative values?
	- [x] Accepts values in random Order	
3. **Sort** these numbers in either **ascending** or **descending** order – the **user should choose the order**.
	- [x] Sorted by user choice
		- [x] ascending or descending 
		- [x] Tidy Sort
4. The **ordered sequence should be inserted into the database** along with the **direction** that the sequence was sorted in and the **time taken** to perform the sort. 
	- [x] Inserted into the database
		- [x] Sequence
		- [x] direction
		- [x] time taken
		- [x] create repository
5. **Feedback** to the user the result of the operation (i.e. whether the **operation was successful**, any **validation** issues with the submission or any **errors** that occurred). 
	- [ ] User Provided with feedback
		- [x] Validation 
		- [x] errors
		- [ ] success
		- [x] Localization
6. **Display the results** of all sorts **including the sort direction** and **time taken**. 
	- [x] Results displayed
		- [x] sequence
		- [x] direction
		- [x] time taken
		- [x] Pagination
7. Allow the user to **export all of the sorts as JSON**. 
	- [x] Export option on display page to export all 

**Please document all assumptions and decisions taken separately** and submit with final code base.

- Created Model
- Schaloleded Controller
- Dealt with List Storage
	- More work is needed
	- Currenltly Sorted as String
- Intialied Database
- Initial test
- Added number validation
- Added Sorting Code
	- Used System Diagnostics Stopwartch

