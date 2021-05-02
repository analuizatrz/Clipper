module.exports = {
  root: true,
  env: {
    node: true
  },
  // plugins: ['prettier'],
  extends: [
    // 'plugin:prettier/recommended',
    'prettier/prettier',
    // 'prettier',
    '@vue/typescript',
    'plugin:vue/essential',
    'eslint:recommended'
  ],
  parserOptions: {
    ecmaVersion: 2020
  },
  rules: {
    'arrow-body-style': 'off',
    'prefer-arrow-callback': 'off',
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off'
  },
  overrides: [
    {
      files: ['**/__tests__/*.{j,t}s?(x)', '**/tests/unit/**/*.spec.{j,t}s?(x)'],
      env: {
        jest: true
      }
    }
  ]
};
