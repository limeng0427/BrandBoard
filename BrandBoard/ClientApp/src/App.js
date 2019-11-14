import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { BrandBoard } from './components/BrandBoard';


//import './custom.css'
import './style.css'
export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={BrandBoard} />
      </Layout>
    );
  }
}
