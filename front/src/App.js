import { Route, Routes } from 'react-router-dom';
import './App.scss';

import MainTemplate from './templates/main/main.template';

import OffersListView from './views/offersList/offersList';
import OfferDetailsView from './views/offerDetails/offerDetails';

import OffersService from './services/offers.service';

function App() {
  return <Routes>
    <Route path='/' element={<MainTemplate />} >
      <Route path="/" element={<OffersListView OffersService={new OffersService()} />} />
      <Route path="/offers" element={<OffersListView OffersService={new OffersService()} />} />
      <Route path='/offers/:id' element={<OfferDetailsView OffersService={new OffersService} />} ></Route>
    </Route>
  </Routes>
}

export default App;
