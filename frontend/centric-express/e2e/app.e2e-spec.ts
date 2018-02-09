import { CentricExpressPage } from './app.po';

describe('centric-express App', () => {
  let page: CentricExpressPage;

  beforeEach(() => {
    page = new CentricExpressPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
