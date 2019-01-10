﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return ToDictionaryCore(source, keySelector, x => x, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return ToDictionaryCore(source, keySelector, x => new ValueTask<TSource>(x), EqualityComparer<TKey>.Default, cancellationToken);
        }

#if !NO_DEEP_CANCELLATION
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return ToDictionaryCore(source, x => keySelector(x, cancellationToken), x => new ValueTask<TSource>(x), EqualityComparer<TKey>.Default, cancellationToken);
        }
#endif

        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return ToDictionaryCore(source, keySelector, x => x, comparer, cancellationToken);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return ToDictionaryCore(source, keySelector, x => new ValueTask<TSource>(x), comparer, cancellationToken);
        }

#if !NO_DEEP_CANCELLATION
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return ToDictionaryCore(source, x => keySelector(x, cancellationToken), x => new ValueTask<TSource>(x), comparer, cancellationToken);
        }
#endif

        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));
            if (elementSelector == null)
                throw Error.ArgumentNull(nameof(elementSelector));

            return ToDictionaryCore(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));
            if (elementSelector == null)
                throw Error.ArgumentNull(nameof(elementSelector));

            return ToDictionaryCore(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);
        }

#if !NO_DEEP_CANCELLATION
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));
            if (elementSelector == null)
                throw Error.ArgumentNull(nameof(elementSelector));

            return ToDictionaryCore(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);
        }
#endif

        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));
            if (elementSelector == null)
                throw Error.ArgumentNull(nameof(elementSelector));

            return ToDictionaryCore(source, keySelector, elementSelector, comparer, cancellationToken);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));
            if (elementSelector == null)
                throw Error.ArgumentNull(nameof(elementSelector));

            return ToDictionaryCore(source, keySelector, elementSelector, comparer, cancellationToken);
        }

#if !NO_DEEP_CANCELLATION
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));
            if (elementSelector == null)
                throw Error.ArgumentNull(nameof(elementSelector));

            return ToDictionaryCore(source, keySelector, elementSelector, comparer, cancellationToken);
        }
#endif

        private static async Task<Dictionary<TKey, TElement>> ToDictionaryCore<TSource, TKey, TElement>(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            var d = new Dictionary<TKey, TElement>(comparer);

#if CSHARP8 && AETOR_HAS_CT // CS0656 Missing compiler required member 'System.Collections.Generic.IAsyncEnumerable`1.GetAsyncEnumerator'
            await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                var key = keySelector(item);
                var value = elementSelector(item);

                d.Add(key, value);
            }
#else
            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var x = e.Current;

                    var key = keySelector(x);
                    var value = elementSelector(x);

                    d.Add(key, value);
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }
#endif

            return d;
        }

        private static async Task<Dictionary<TKey, TElement>> ToDictionaryCore<TSource, TKey, TElement>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, Func<TSource, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            var d = new Dictionary<TKey, TElement>(comparer);

#if CSHARP8 && AETOR_HAS_CT // CS0656 Missing compiler required member 'System.Collections.Generic.IAsyncEnumerable`1.GetAsyncEnumerator'
            await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                var key = await keySelector(item).ConfigureAwait(false);
                var value = await elementSelector(item).ConfigureAwait(false);

                d.Add(key, value);
            }
#else
            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var x = e.Current;

                    var key = await keySelector(x).ConfigureAwait(false);
                    var value = await elementSelector(x).ConfigureAwait(false);

                    d.Add(key, value);
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }
#endif

            return d;
        }

#if !NO_DEEP_CANCELLATION
        private static async Task<Dictionary<TKey, TElement>> ToDictionaryCore<TSource, TKey, TElement>(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            var d = new Dictionary<TKey, TElement>(comparer);

#if CSHARP8 && AETOR_HAS_CT // CS0656 Missing compiler required member 'System.Collections.Generic.IAsyncEnumerable`1.GetAsyncEnumerator'
            await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                var key = await keySelector(item, cancellationToken).ConfigureAwait(false);
                var value = await elementSelector(item, cancellationToken).ConfigureAwait(false);

                d.Add(key, value);
            }
#else
            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var x = e.Current;

                    var key = await keySelector(x, cancellationToken).ConfigureAwait(false);
                    var value = await elementSelector(x, cancellationToken).ConfigureAwait(false);

                    d.Add(key, value);
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }
#endif

            return d;
        }
#endif
    }
}
