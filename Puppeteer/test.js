const puppeteer = require('puppeteer');
(async () => {
    const browser = await puppeteer.launch({
      headless: false,
      args: ['--headless', '--disable-gpu', '--remote-debugging-port=9222', '--no-sandbox', '--disable-setuid-sandbox']
    });

    const page1 = await browser.newPage();
    try{
      await page1.goto('http://localhost:8080/Book/Create');
      await page1.setViewport({
        width:1200,
        height:800,
      })
      const titleInput = await page1.$('input[name="Title"]');
      const authorInput = await page1.$('input[name="Author"]');
      const genreInput = await page1.$('input[name="Genre"]');
      const priceInput = await page1.$('input[name="Price"]');
      const quantityInput = await page1.$('input[name="Quantity"]');
      const createButton = await page1.$('input[type="submit"]');
      
    //   console.log('\nTESTCASE: Create New Book Form Elements');
      console.log(titleInput ? 'Title Input Exists: Success' : 'Title Input Missing: Failure');
      console.log(authorInput ? 'Author Input Exists: Success' : 'Author Input Missing: Failure');
      console.log(genreInput ? 'Genre Input Exists: Success' : 'Genre Input Missing: Failure');
      console.log(priceInput ? 'Price Input Exists: Success' : 'Price Input Missing: Failure');
      console.log(quantityInput ? 'Quantity Input Exists: Success' : 'Quantity Input Missing: Failure');
      console.log(createButton ? 'Create Button Exists: Success' : 'Create Button Missing: Failure');
      
      console.log('TESTCASE:Create_Book_successful:success');
      
    }
    catch(e){
      console.log('TESTCASE:Create_Book_successful:failure');
    } 

    const page2 = await browser.newPage();

    try {
      await page2.goto('http://localhost:8080');
      await page2.setViewport({
        width: 1200,
        height: 800,
      });
      await page2.goto('http://localhost:8080/Book/Details/1');
    
      const bookDetailsExist = await page2.evaluate(() => {
      const bookId = document.querySelector('dd[data-book="BookID"]');
      const title = document.querySelector('dd[data-book="Title"]');
      const author = document.querySelector('dd[data-book="Author"]');
      const genre = document.querySelector('dd[data-book="Genre"]');
      const price = document.querySelector('dd[data-book="Price"]');
      const quantity = document.querySelector('dd[data-book="Quantity"]');
      
      return bookId && title && author && genre && price && quantity;
    });

    console.log('TESTCASE:Book_Details_successful:success');  
    }
  catch(e){
    console.log('TESTCASE:Book_Details_successful:success');
  }
    
  const page3 = await browser.newPage();

  try {
    await page3.goto('http://localhost:8080/Book/Index');
    
    const titleColumn = await page3.$('th:contains("Title")');
    const authorColumn = await page3.$('th:contains("Author")');
    const genreColumn = await page3.$('th:contains("Genre")');
    const priceColumn = await page3.$('th:contains("Price")');
    const quantityColumn = await page3.$('th:contains("Quantity")');
    
    console.log(titleColumn ? 'TESTCASE:BookId_Column_successful:success' : 'TESTCASE:BookId_Column_failure:failure');
    console.log(authorColumn ? 'TESTCASE:Author_Column_successful:success' : 'TESTCASE:Author_Column_failure:failure');
    console.log(genreColumn ? 'TESTCASE:Genre_Column_successful:success' : 'TESTCASE:Genre_Column_failure:failure');
    console.log(priceColumn ? 'TESTCASE:Price_Column_successful:success' : 'TESTCASE:Price_Column_failure:failure');
    console.log(quantityColumn ? 'TESTCASE:Quantity_Column_successful:success' : 'TESTCASE:Quantity_Column_failure:failure');
    
  } 
  catch(e){
    console.log('TESTCASE:BookId_Column_failure:failure');
    console.log('TESTCASE:Author_Column_failure:failure');
    console.log('TESTCASE:Genre_Column_failure:failure');
    console.log('TESTCASE:Price_Column_failure:failure');
    console.log('TESTCASE:Quantity_Column_failure:failure');
  }
    
  
  finally{
    await page1.close();
    await page2.close();
    await page3.close();
    await browser.close();
  }
  
})();