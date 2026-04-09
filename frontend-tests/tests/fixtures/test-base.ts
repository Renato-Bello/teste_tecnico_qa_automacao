import { test as base, expect } from '@playwright/test';
import { BasePage } from '../pages/BasePage';
import { HomePage } from '../pages/HomePage';
import { DashBoardPage } from '../pages/DashBoardPage';
import { PessoasPage } from '../pages/PessoasPage';
import { TransacoesPage } from '../pages/TransacoesPage';

type Fixtures = {
  basePage: BasePage;
  homePage: HomePage;
  dashboardPage: DashBoardPage;
  pessoasPage: PessoasPage;
  transacoesPage: TransacoesPage;
};

export const test = base.extend<Fixtures>({
  basePage: async ({ page }, use) => {
    await use(new BasePage(page));
  },

  homePage: async ({ page }, use) => {
    await use(new HomePage(page));
  },

  dashboardPage: async ({ page }, use) => {
    await use(new DashBoardPage(page));
  },

  pessoasPage: async ({ page }, use) => {
    await use(new PessoasPage(page));
  },

 transacoesPage: async ({ page }, use) => {
  await use(new TransacoesPage(page));
},
});

export { expect };