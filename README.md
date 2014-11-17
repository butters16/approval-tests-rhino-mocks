approval-tests-rhino-mocks
==========================

Playground for using [Approval Tests](http://approvaltests.sourceforge.net/) with [Rhino Mocks](http://hibernatingrhinos.com/oss/rhino-mocks) inputs for characterization tests.

I am using this as a proof of concept. This is the idea:

1. Take existing legacy code
1. Make dependencies mockable
1. Use [Approval Tests](http://approvaltests.sourceforge.net/) combination approvals to quickly generate characterization tests close to 100% coverage
1. Refactor like crazy, especially to break into smaller classes with their own unit tests
1. Throw away characterization tests?
1. Profit

Note this was put together using MonoDevelop for demo purposes.
