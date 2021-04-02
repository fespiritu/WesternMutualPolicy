import React, { Component } from 'react';
import PolicyView from './policyView';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Policies</h1>
        <PolicyView />
      </div>
    );
  }
}
