const path = require('path');
const webpack = require('webpack');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const ExtractTextWebpackPlugin = require('extract-text-webpack-plugin');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MinifyPlugin = require('babel-minify-webpack-plugin');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return [
        {
            entry: {
                main: './ClientApp/boot.js'
                /*vendor: [
                    'bootstrap',
                    'popper.js',
                    'jquery'
                ]*/
            },
            devtool: isDevBuild ? 'eval-source-map' : false,
            output: {
                path: path.resolve(__dirname, './wwwroot/dist'),
                publicPath: '/dist/',
                filename: isDevBuild ? 'js/[name].js' : 'js/[name].[chunkhash].js'
                //filename: '[name].js'
            },
            module: {
                rules: [
                    {
                        test: /\.(css|scss)$/,
                        use: ExtractTextWebpackPlugin.extract({
                            fallback: 'style-loader',
                            use: ['css-loader', 'postcss-loader', 'sass-loader']
                        })
                    },
                    {
                        test: /\.(vue|ts)$/,
                        loader: 'vue-loader',
                        options: {
                            loaders: {
                                js: 'babel-loader'
                            }
                        }
                    },
                    {
                        test: /\.js$/,
                        loader: 'babel-loader',
                        exclude: /node_modules/
                    },
                    {
                        test: /\.(eot|svg|ttf|woff|woff2)$/,
                        use: [
                            {
                                loader: 'file-loader',
                                options: {
                                    name: isDevBuild ? 'fonts/[name].[ext]' : 'fonts/[hash]-[name].[ext]'
                                }
                            }
                        ]
                    },
                    {
                        test: /\.(png)$/,
                        use: [
                            {
                                loader: 'url-loader',
                                options: {
                                    limit: 8000,
                                    name: isDevBuild ? 'images/[name].[ext]' : 'images/[hash]-[name].[ext]'
                                }
                            }
                        ]
                    }
                ]
            },
            resolve: {
                extensions: ['.js', '.vue', '.ts']
            },
            plugins: [
                new ExtractTextWebpackPlugin(isDevBuild ? 'vendor.css' : 'vendor.[chunkhash].css'),
                //new ExtractTextWebpackPlugin('vendor.css'),
                /*new webpack.ProvidePlugin({
                    $: 'jquery',
                    jQuery: 'jquery',
                    'window.jQuery': 'jquery'
                }),*/
                new webpack.DefinePlugin({
                    'process.env': {
                        NODE_ENV: isDevBuild ? '"development"' : '"production"'
                    }
                }),
                new CleanWebpackPlugin(
                    ['./wwwroot/dist', './Views/Default/Index.cshtml'],
                    {
                        root: __dirname,
                        verbose: false
                    }
                ),
                new HtmlWebpackPlugin({
                    title: 'Custom Template',
                    template: './ClientApp/templates/Index.cshtml',
                    filename: path.resolve(__dirname, './Views/Default/Index.cshtml')
                }),
                new webpack.optimize.CommonsChunkPlugin({
                    name: 'vendor'
                })
            ].concat(isDevBuild
                ? []
                : [
                    new UglifyJsPlugin({
                        uglifyOptions: {
                            output: {
                                comments: false
                            },
                            compress: true,
                            warnings: false
                        }
                    })
                ])
        }
    ];
};