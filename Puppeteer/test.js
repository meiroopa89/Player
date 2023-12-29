    //  const puppeteer = require('puppeteer');
    //     (async () => {
    //         const browser = await puppeteer.launch({
    //         headless: false,
    //         args: ['--headless', '--disable-gpu', '--remote-debugging-port=9222', '--no-sandbox', '--disable-setuid-sandbox']
    //     });

    //     const page = await browser.newPage();
    //     try{
    //     await page.goto('http://localhost:8080/');
    //     }
    // });


    const puppeteer = require('puppeteer');
(async () => {
    const browser = await puppeteer.launch({
      headless: false,
      args: ['--headless', '--disable-gpu', '--remote-debugging-port=9222', '--no-sandbox', '--disable-setuid-sandbox']
    });

    const page = await browser.newPage();
    try{
      await page.goto('http://localhost:8080/');
      await page.setViewport({
        width:1200,
        height:1200,
      })
        
      
    }
    catch(e){
      console.log('TESTCASE:Headers_are_correct:failure');
    }

    const page1 = await browser.newPage();

    try {
      await page1.goto('http://localhost:8080');
      await page1.setViewport({
        width: 1200,
        height: 800,
      });
    
      
      
    }
  catch(e){
    console.log('TESTCASE:Search_button_exists:failure');
  }
    
    
  
  finally{
    await page.close();
    await page1.close();
    await page2.close();
    // await page3.close();
    // await page5.close();
    // await page6.close();
    // await page7.close();
    // await page8.close();
    await browser.close();
  }
  
})();