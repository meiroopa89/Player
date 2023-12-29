
const puppeteer = require('puppeteer');
(async () => {
    const browser = await puppeteer.launch({
      headless: false,
      args: ['--headless', '--disable-gpu', '--remote-debugging-port=9222', '--no-sandbox', '--disable-setuid-sandbox']
    });

    const page1 = await browser.newPage();
    try{
      await page1.goto('https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/Book/Create');
      await page1.setViewport({
        width:1200,
        height:800,
      })
      const titleInput = await page1.$('input[name="Title"]');
      const authorInput = await page1.$('input[name="Author"]');
      const genreInput = await page1.$('input[name="Genre"]');
      const priceInput = await page1.$('input[name="Price"]');
      const quantityInput = await page1.$('input[name="Quantity"]');
      
 
      if (titleInput != null && authorInput!= null && genreInput!=null && priceInput!=null && quantityInput!=null)
      console.log('TESTCASE:Create_Book_Input_successful:success');
      else
      console.log('TESTCASE:Create_Book_Input_successful:failure');
      
    }
    catch(e){
      console.log('TESTCASE:Create_Book_Input_successful:failure');
    } 

    const page2 = await browser.newPage();

    try {
      await page2.goto('https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io');
      await page2.setViewport({
        width: 1200,
        height: 800,
      });
      await page2.goto('https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/Book/Details/1');
    
      const bookDetailsExist = await page2.evaluate(() => {
      const bookId = document.querySelector('dd[data-book="BookID"]');
      const title = document.querySelector('dd[data-book="Title"]');
      const author = document.querySelector('dd[data-book="Author"]');
      const genre = document.querySelector('dd[data-book="Genre"]');
      const price = document.querySelector('dd[data-book="Price"]');
      const quantity = document.querySelector('dd[data-book="Quantity"]');
      
      return bookId && title && author && genre && price && quantity;
    });
    console.log('TESTCASE:Book_Details_exist_successful:success');
    }
  catch(e){
    console.log('TESTCASE:Book_Details_exist_successful:failure');
  }

  const page3 = await browser.newPage();
  try
  {
    await page3.goto('https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/Book/Create');

    await Promise.all([
      page3.waitForNavigation(),
      page3.click('a[href="/"]'),
    ]);
    console.log("TESTCASE:Back_To_List_Navigate_successful:success");
}
  catch (error) {
    console.log('TESTCASE:Back_To_List_Navigate_successful:failure');
  }
  
  finally{
    await page1.close();
    await page2.close();
    await page3.close();
    await browser.close();
  }
  
})();