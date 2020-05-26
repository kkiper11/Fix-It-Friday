import ApolloClient, { HttpLink } from 'apollo-boost';

const client = new ApolloClient({
  uri: 'http://localhost:52972/GraphQL',
  fetchOptions: {
    mode: 'no-cors',
  } as HttpLink.Options,
});

export default client;
