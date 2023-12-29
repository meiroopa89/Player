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
      const titleInput = await page.$('input[name="Title"]');
      const authorInput = await page.$('input[name="Author"]');
      const genreInput = await page.$('input[name="Genre"]');
      const priceInput = await page.$('input[name="Price"]');
      const quantityInput = await page.$('input[name="Quantity"]');
      const createButton = await page.$('input[type="submit"]');
      
      console.log('\nTESTCASE: Create New Book Form Elements');
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
      await page1.goto('http://localhost:8080');
      await page1.setViewport({
        width: 1200,
        height: 800,
      });
      await page.goto('http://localhost:8080/Book/Details/1');
    
      const bookDetailsExist = await page.evaluate(() => {
      const bookId = document.querySelector('dd[data-book="BookID"]');
      const title = document.querySelector('dd[data-book="Title"]');
      const author = document.querySelector('dd[data-book="Author"]');
      const genre = document.querySelector('dd[data-book="Genre"]');
      const price = document.querySelector('dd[data-book="Price"]');
      const quantity = document.querySelector('dd[data-book="Quantity"]');
      
      return bookId && title && author && genre && price && quantity;
    });
    
    console.log('\nTESTCASE: Book Details Display');
    console.log(bookDetailsExist ? 'Book Details Displayed: Success' : 'Book Details Missing: Failure');  
    }
  catch(e){
    console.log('TESTCASE:Search_button_exists:failure');
  }
    
    
  
  finally{
    await page.close();
    await page1.close();
    await page2.close();
    await browser.close();
  }
  
})();