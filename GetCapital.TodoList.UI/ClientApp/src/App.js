import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { TodoList } from './components/todo/list/TodoList';
import { TodoItem } from './components/todo/item/TodoItem';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={TodoList} />
        <Route path='/todo-item' component={TodoItem} />
      </Layout>
    );
  }
}
